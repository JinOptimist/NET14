using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using AutoMapper;
using Net14.Web.Models;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Net14.Web.Controllers.AutorizeAttribute;
using Net14.Web.Models.SocialModels.Attributes;

namespace Net14.Web.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [SocialAPI]
    public class SocialController : ControllerBase
    {
        private UserService _userService;
        private SocialPostRepository _socialPostRepository;
        private SocialCommentRepository _socialCommentRepository;
        private IMapper _mapper;
        private UserFriendRequestRepository _userFriendRequestRepository;
        private FriendRequestService _friendRequestService;
        private SocialUserRepository _socialUserRepository;
        public SocialController(UserService userService,
            SocialPostRepository socialPostRepository, SocialCommentRepository socialCommentRepository,
            IMapper mapper, UserFriendRequestRepository userFriendRequestRepository, FriendRequestService friendRequestService,
            SocialUserRepository socialUserRepository)
        {
            _userService = userService;
            _socialPostRepository = socialPostRepository;
            _socialCommentRepository = socialCommentRepository;
            _mapper = mapper;
            _userFriendRequestRepository = userFriendRequestRepository;
            _friendRequestService = friendRequestService;
            _socialUserRepository = socialUserRepository;

        }

        [Authorize]
        public bool AddLike(int postId)
        {
            var post = _socialPostRepository.Get(postId);
            var currentUser = _userService.GetCurrent();

            if (_socialPostRepository.AddLike(post, currentUser))
            {
                return true;
            }

            return false;
        }

        [Authorize]
        public bool RemoveLike(int postId)
        {
            var post = _socialPostRepository.Get(postId);
            var currentUser = _userService.GetCurrent();

            if (_socialPostRepository.RemoveLike(post, currentUser))
            {
                return true;
            }

            return false;
        }

        [Authorize]
        public SocialUserViewModel AddComment(int postId, string text)
        {

            if (text == null)
            {
                return null;
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

            return _mapper.Map<SocialUserViewModel>(_userService.GetCurrent());
        }

        [Authorize]
        public List<FriendRequestViewModel> Notification()
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

            return receivedModel;
        }

        public List<SocialCommentViewModel> GetComments(int postId)
        {
            var post = _socialPostRepository.Get(postId);

            var comments = _mapper.Map<List<SocialCommentViewModel>>(post.Comments);

            return comments;
        }

        [Authorize]
        public IActionResult AddFriend(int friendId)
        {
            var currentUserId = _userService.GetCurrent().Id;
            _friendRequestService.CreateFriendRequest(currentUserId, friendId);
            return Ok();
        }

        [Authorize]
        public bool AcceptFriend(int friendId)
        {
            var user = _userService.GetCurrent();
            _friendRequestService.Accept(friendId, user.Id);

            return true;
        }

        [Authorize]
        public bool DeclineFriend(int friendId)
        {

            var user = _userService.GetCurrent();
            _friendRequestService.Decline(friendId, user.Id);

            return true;
        }

        [HasRole(SiteRole.Admin)]
        [HttpGet]
        public void BlockUser(int userId)
        {
            var user = _socialUserRepository.Get(userId);
            user.IsBlocked = true;
            _socialUserRepository.Save(user);
        }
        [HttpGet]
        public bool BlockUserApi(int id)
        {
            var user = _socialUserRepository.Get(id);
            user.IsBlocked = true;
            _socialUserRepository.Save(user);
            return true;
        }

        [HasRole(SiteRole.Admin)]
        [HttpGet]
        public void UnblockUser(int userId)
        {

            var user = _socialUserRepository.Get(userId);
            user.IsBlocked = false;
            _socialUserRepository.Save(user);
        }

        [HttpGet]
        public List<SocialUserViewModel> GetUsers()
        {
            var users = _socialUserRepository.GetAll();

            return _mapper.Map<List<SocialUserViewModel>>(users);
        }

        [HttpGet("{id}")]
        public SocialUserViewModel GetUser(int id)
            => _mapper.Map<SocialUserViewModel>(_socialUserRepository.Get(id));

    }
}
