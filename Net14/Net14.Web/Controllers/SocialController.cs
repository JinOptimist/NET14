using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.Repositories;
using Microsoft.AspNetCore.Authorization;
using Net14.Web.Services;
using AutoMapper;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Net14.Web.Controllers.AutorizeAttribute;
using Microsoft.AspNetCore.SignalR;
using Net14.Web.SignalRHubs;

namespace Net14.Web.Controllers
{
    public class SocialController : Controller

    {
        private SocialUserRepository _socialUserRepository;
        private SocialPostRepository _socialPostRepository;
        private SocialCommentRepository _socialCommentRepository;
        private UserService _userService;
        private IMapper _mapper;
        private FriendRequestService _friendRequestService;
        private UserFriendRequestRepository _userFriendRequestRepository;
        private RecomendationsService _recomendationsService;
        private IHubContext<NotificationsHub> _notificationsHub;

        public SocialController(SocialUserRepository socialUserRepository,
            SocialPostRepository socialPostRepository,
            SocialCommentRepository socialCommentRepository,
            UserService userService, IMapper mapper,
            FriendRequestService friendRequestService,
            UserFriendRequestRepository userFriendRequestRepository,
            RecomendationsService recomendationsService,
            IHubContext<NotificationsHub> hubContext)
        {
            _notificationsHub = hubContext;
            _socialPostRepository = socialPostRepository;
            _socialUserRepository = socialUserRepository;
            _socialCommentRepository = socialCommentRepository;
            _userService = userService;
            _mapper = mapper;
            _friendRequestService = friendRequestService;
            _userFriendRequestRepository = userFriendRequestRepository;
            _recomendationsService = recomendationsService;
        }
        [HttpGet]
        public IActionResult Index()
        {

            var postArr = _socialPostRepository.GetAll();
            var topThree = _mapper.Map<List<SocialPostViewModel>>(_recomendationsService.GetIndexRecomendations());
            var viewPost = _mapper.Map<List<SocialPostViewModel>>(postArr);

            
            var finalModel = new SocialPostWithTopViewModel() 
            {
                Posts = viewPost,
                TopThreePost = topThree
            };

            return View(finalModel);
        }

        [HttpPost]
        public IActionResult Index(string ImageUrl, string CommentOfUser)
        {
            var user = _userService.GetCurrent();
            var post = new PostSocial()
            {
                CommentOfUser = CommentOfUser,
                ImageUrl = ImageUrl,
                User = user
            };
            _socialPostRepository.Save(post);

            return Redirect("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Settings()
        {
            var currentUser = _userService.GetCurrent();
            var model = _mapper.Map<SocialUserSettingsViewModel>(currentUser);

            return View(model);
        }

        [HttpPost]
        public IActionResult Settings(SocialUserSettingsViewModel socialUserSettingsViewModel)
        {
            if (ModelState.IsValid)
            {
                var currentUser = _userService.GetCurrent();

                currentUser.Age = socialUserSettingsViewModel.Age;
                currentUser.City = socialUserSettingsViewModel.City;
                currentUser.Country = socialUserSettingsViewModel.Country;
                currentUser.FirstName = socialUserSettingsViewModel.FirstName;
                currentUser.LastName = socialUserSettingsViewModel.LastName;

                _socialUserRepository.Save(currentUser);
            }

            return RedirectToAction("Settings");
        }
        [HttpGet]
        public IActionResult ShowAllUsers()
        {
            var currentUser = _userService.GetCurrent();
            var dbUsers = _socialUserRepository.GetAll();

            if (currentUser == null)
            {
                var model = _mapper.Map<List<SocialUserViewModel>>(dbUsers);
                return View(model);

            }

            var modelNoCurrent = dbUsers.Where(user => user.Id != currentUser.Id)
                .Select(db =>
                {
                    if (currentUser.Friends.Contains(db))
                    {
                        var mod = _mapper.Map<SocialUserViewModel>(db);
                        mod.IsFriend = true;
                        return mod;
                    }
                    if (currentUser.FriendRequestSent.Exists(req => req.Receiver.Id == db.Id && req.FriendRequestStatus == FriendRequestStatus.Pending)) 
                    {
                        var mod = _mapper.Map<SocialUserViewModel>(db);
                        mod.IsRequested = true;
                        return mod;
                    }
                    var modNotFriend = _mapper.Map<SocialUserViewModel>(db);
                    return modNotFriend;

                }).ToList();


            return View(modelNoCurrent);
        }

        [HttpPost]
        public IActionResult ShowAllUsers(string FullName, int Age, string Country, string City, string FirstName, string LastName)
        {

            var users = _socialUserRepository.GetBy(FullName, Age, Country, City, FirstName, LastName);
            var model = _mapper.Map<List<SocialUserViewModel>>(users);


            return View(model);
        }


        public IActionResult AboutUs()
        {
            return View();
        }


        public IActionResult ShowProfile()
        {
            var user = new UserSocial();

            return View(user);
        }

        public IActionResult ShowPagesProfile()
        {
            var postUser = _mapper.Map<List<SocialPostViewModel>>(_userService.GetCurrent().Posts);
            var user = _userService.GetCurrent();
            var model = _mapper.Map<SocialProfileViewModel>(user);
            model.UserPost = postUser;

            return View(model);
        }

        [Authorize]
        public IActionResult MyProfile()
        {
            var user = _userService.GetCurrent();
            var model = _mapper.Map<SocialProfileViewModel>(user);

            return View(model);
        }

        [Authorize]
        public IActionResult AddComment(int postId, string text)
        {
            if (text == null)
            {
                return StatusCode(400);
            }
            var post = _socialPostRepository.Get(postId);
            var currentUser = _userService.GetCurrent();

            var comment = new SocialComment()
            {
                Post = post,
                Text = text,
                User = currentUser
            };

            _socialCommentRepository.Save(comment);
            return Json(_mapper.Map<SocialUserViewModel>(_userService.GetCurrent()));
        }

        public IActionResult GetComments(int postId) 
        {
            var post = _socialPostRepository.Get(postId);

            var comments = _mapper.Map<List<SocialCommentViewModel>>(post.Comments);

            return Json(comments);
        }

        [Authorize]
        public IActionResult AddFriend(int friendId)
        {
            var currentUserId = _userService.GetCurrent().Id;
            _friendRequestService.CreateFriendRequest(currentUserId, friendId);
            return Ok();

        }
        [Authorize]
        public IActionResult Notification()
        {
            var currentUser = _userService.GetCurrent();

            var recievedRequests = currentUser.FriendRequestReceived
                .ToList();

            recievedRequests.ForEach(el => el.IsViewedByReceiver = true);
            _userFriendRequestRepository.SaveList(recievedRequests);


            var closeSentRequests = currentUser.FriendRequestSent
                .Where(req => req.FriendRequestStatus != FriendRequestStatus.Pending).ToList();

            closeSentRequests.ForEach(el => el.IsViewedBySender = true);
            _userFriendRequestRepository.SaveList(closeSentRequests);

            var receivedModel = _mapper.Map<List<FriendRequestViewModel>>(recievedRequests);
            receivedModel.ForEach(req => req.Type = RequestViewModelType.Received);

            var sentModel = _mapper.Map<List<FriendRequestViewModel>>(closeSentRequests);
            sentModel.ForEach(req => req.Type = RequestViewModelType.Sent);

            receivedModel.AddRange(sentModel);

            return Json(receivedModel);
        }

        [Authorize]
        public IActionResult Friends()
        {
            var currentUser = _userService.GetCurrent();
            
            var friends = currentUser.Friends;

            var model = _mapper.Map<List<SocialUserViewModel>>(friends);

            return View(model);
        }

        [Authorize]
        public IActionResult AcceptFriend(int friendId)
        {

            var user = _userService.GetCurrent();
            _friendRequestService.Accept(friendId, user.Id);

            return Ok();

        }

        [Authorize]
        public IActionResult DeclineFriend(int friendId)
        {
            var user = _userService.GetCurrent();
            _friendRequestService.Decline(friendId, user.Id);

            return Ok();

        }
        [HasRole(SiteRole.Admin)]
        public IActionResult BlockUser(int userId) 
        {
            var user = _socialUserRepository.Get(userId);
            user.IsBlocked = true;
            _socialUserRepository.Save(user);
            return Redirect($"/Social/ShowAllUsers");
        }

        [HasRole(SiteRole.Admin)]
        public IActionResult UnblockUser(int userId) 
        {
            var user = _socialUserRepository.Get(userId);
            user.IsBlocked = false;
            _socialUserRepository.Save(user);
            return Redirect($"/Social/ShowAllUsers");
        }

        public IActionResult AddPost(string text, string ImageUrl) 
        {
            var postDb = new PostSocial()
            {
                User = _userService.GetCurrent(),
                CommentOfUser = text,
                ImageUrl = ImageUrl,
            };

            _socialPostRepository.Save(postDb);

            return Json(_mapper.Map<SocialPostViewModel>(postDb));

        }
    }
}
