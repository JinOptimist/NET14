using Microsoft.AspNetCore.Http;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Services
{
    public class UserService
    {
        private SocialUserRepository _socialUserRepository;
        private SocialFriendRepository _socialFriendRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public UserService(
            SocialUserRepository socialUserRepository,
            IHttpContextAccessor httpContextAccessor,
            SocialFriendRepository socialFriendRepository)
        {
            _socialUserRepository = socialUserRepository;
            _httpContextAccessor = httpContextAccessor;
            _socialFriendRepository = socialFriendRepository;
        }

        public UserSocial GetCurrent()
        {
            var idsStr = _httpContextAccessor
                .HttpContext
                .User
                .Claims
                .FirstOrDefault(x => x.Type == "Id")
                ?.Value;
            if (idsStr == null)
            {
                return null;
            }

            var id = int.Parse(idsStr);

            var user = _socialUserRepository.Get(id);

            return user;
        }

        public bool CheckIfFriends(int requestUserId, int targetUserId)
        {
            return _socialFriendRepository.GetAll().Any(uf =>
                (uf.UserId == requestUserId && uf.FriendId == targetUserId) || (uf.UserId == targetUserId && uf.FriendId == requestUserId));
        }

        public void MakeFriends(int senderId, int receiverId)
        {
            if (_socialUserRepository.Get(senderId) != null && _socialUserRepository.Get(senderId) != null &&
               !CheckIfFriends(senderId, receiverId))
            {
                var userFriendOne = new UserFriend
                {
                    UserId = senderId,
                    FriendId = receiverId
                };

                var userFriendTwo = new UserFriend
                {
                    UserId = receiverId,
                    FriendId = senderId
                };

                _socialFriendRepository.Save(userFriendOne);
                _socialFriendRepository.Save(userFriendTwo);

            }
        }

    }
}
