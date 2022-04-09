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
namespace Net14.Web.Controllers
{
    public class SocialController : Controller

    {
        private SocialUserRepository _socialUserRepository;
        private SocialPostRepository _socialPostRepository;
        private SocialCommentRepository _socialCommentRepository;
        private SocialFriendRepository _socialFriendRepository;
        private UserService _userService;
        private IMapper _mapper;
        private FriendRequestService _friendRequestService;
        private UserFriendRequestRepository _userFriendRequestRepository;

        public SocialController(SocialUserRepository socialUserRepository,
            SocialPostRepository socialPostRepository,
            SocialCommentRepository socialCommentRepository,
            SocialFriendRepository socialFriendRepository,
            UserService userService, IMapper mapper,
            FriendRequestService friendRequestService,
            UserFriendRequestRepository userFriendRequestRepository)
        {
            _socialPostRepository = socialPostRepository;
            _socialUserRepository = socialUserRepository;
            _socialCommentRepository = socialCommentRepository;
            _userService = userService;
            _socialFriendRepository = socialFriendRepository;
            _mapper = mapper;
            _friendRequestService = friendRequestService;
            _userFriendRequestRepository = userFriendRequestRepository;
        }

        public IActionResult Index()
        {

            var postArr = _socialPostRepository.GetAll();
            var viewPost = _mapper.Map<List<SocialPostViewModel>>(postArr);

            return View(viewPost);
        }

        [Authorize]
        public IActionResult Settings()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ShowAllUsers() 
        {
            var currentUser = _userService.GetCurrent();
            List<SocialUserViewModel> model;
            List<UserSocial> users; 
            if (currentUser == null)
            {
                users = _socialUserRepository.GetAll();
                model = _mapper.Map<List<SocialUserViewModel>>(users);
                return View(model);
            }
            else 
            {
                users = _socialUserRepository.GetAll()
                    .Where(user => user.Id != currentUser.Id)
                    .ToList();
                model = _mapper.Map<List<SocialUserViewModel>>(users);
                foreach (var user in model) 
                {
                    if (currentUser.Friends.Any(us => us.FriendId == user.Id)) 
                    {
                        user.IsFriend = true;
                    }
                }
                return View(model);
            }
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

        public IActionResult ShowPagesProfile(int id)
        {

            var user = _socialUserRepository.Get(id);
            var model = _mapper.Map<SocialProfileViewModel>(user);

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
                return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult AddFriend(int friendId)
        {
            var currentUserId = _userService.GetCurrent().Id;
            _friendRequestService.Create(currentUserId, friendId);

            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult Notification() 
        {
            var user = _userService.GetCurrent();
            var requests = _userFriendRequestRepository.GetAll().Where(req => req.ReceiverId == user.Id & 
                            req.FriendRequestStatus == FriendRequestStatus.Pending);

            var model = _mapper.Map<List<FriendRequestViewModel>>(requests);

            return View(model);


        }
        [Authorize]
        public IActionResult Friends() 
        {
            var currentUserId = _userService.GetCurrent();

            var friends = _socialFriendRepository.FriendsIds(currentUserId.Id);

            var model = _mapper.Map<List<SocialUserViewModel>>(friends);

            return View(model);
        }

        [Authorize]
        public IActionResult AcceptFriend(int friendId) 
        {
            var user = _userService.GetCurrent();
            _friendRequestService.Accept(friendId, user.Id);

            return Redirect("Notification");

        }

        [Authorize]
        public IActionResult DeclineFriend(int friendId) 
        {
            var user = _userService.GetCurrent();
            _friendRequestService.Decline(friendId, user.Id);
            return Redirect("Notification");

        }
    }
}
