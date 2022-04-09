using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Net14.Web.EfStuff.Repositories;

namespace Net14.Web.Services
{
    public class FriendRequestService
    {
        private UserService _userService;
        private SocialFriendRepository _socialFriendRepository;
        private UserFriendRequestRepository _userFriendRequestRepository;
        private SocialUserRepository _socialUserRepository;

        public FriendRequestService(UserService userService, 
            SocialFriendRepository socialFriendRepository,
            UserFriendRequestRepository userFriendRequestRepository,
            SocialUserRepository socialUserRepository)
        {
            _userService = userService;
            _socialFriendRepository = socialFriendRepository;
            _userFriendRequestRepository = userFriendRequestRepository;
            _socialUserRepository = socialUserRepository;
        }

        public void Create(int  senderId, int receiverId)
        {
            if (!Exists(senderId, receiverId) && _socialUserRepository.Exists(senderId) && _socialUserRepository.Exists(receiverId))
            {
                var friendRequest = new UserFriendRequest
                {
                    SenderId = senderId,
                    ReceiverId = receiverId,
                    FriendRequestStatus = FriendRequestStatus.Pending
                };

                _userFriendRequestRepository.Save(friendRequest);
            }
        }

        public void Accept(int senderId, int receiverId)
        {
            if (Exists(senderId, receiverId) && _socialUserRepository.Exists(senderId) && _socialUserRepository.Exists(receiverId))
            {
                var friendRequest = _userFriendRequestRepository.GetAll().FirstOrDefault(fr => fr.ReceiverId == receiverId && fr.SenderId == senderId);
                friendRequest.FriendRequestStatus = FriendRequestStatus.Accepted;
                _userFriendRequestRepository.Save(friendRequest);
                _userService.MakeFriends(senderId, receiverId);
                _userService.MakeFriends(receiverId, senderId);

            }
        }
        public void Decline(int senderId, int receiverId) 
        {
            if (Exists(senderId, receiverId) && _socialUserRepository.Exists(senderId) && _socialUserRepository.Exists(receiverId)) 
            {
                var friendRequest = _userFriendRequestRepository.GetAll();
                var target = friendRequest.Single(req => req.ReceiverId == receiverId);
                _userFriendRequestRepository.Remove(target);
            }
        }

        private bool Exists(int senderId, int receiverId)
        {
            return _userFriendRequestRepository.GetAll().Any(fr => fr.SenderId == senderId && fr.ReceiverId == receiverId);
        }

    }
}
