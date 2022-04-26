using Microsoft.AspNetCore.Http;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.Models.SocialModels;
using Net14.Web.Models;
using AutoMapper;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Net14.Web.EfStuff.DbModel;

namespace Net14.Web.Services
{
    public class UserService
    {
        private SocialUserRepository _socialUserRepository;
        private CalendarUsersRepository _calendarUsersRepository;
        private IHttpContextAccessor _httpContextAccessor;
        private IMapper _mapper;

        public UserService(
            SocialUserRepository socialUserRepository,
            CalendarUsersRepository calendarUsersRepository,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _socialUserRepository = socialUserRepository;
            _calendarUsersRepository = calendarUsersRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
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
        public CalendarUser CalendarGetCurrent()
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

            var user = _calendarUsersRepository.Get(id);

            return user;
        }
        public bool CalendarHasRole(Net14.Web.EfStuff.DbModel.CalendarDbModels.Roles role)
            => CalendarGetCurrent()?.Role.HasFlag(role) ?? false;
        public bool HasRole(SiteRole role)
            => GetCurrent()?.Role.HasFlag(role) ?? false;

        public bool IsAdmin()
            => HasRole(SiteRole.Admin);

        public bool IsStoreAdmin()
            => HasRole(SiteRole.StoreAdmin);

        public int GetUsersNotifications() 
        {
            var currentUser = GetCurrent();
            var res = currentUser.FriendRequestReceived.Where(req => req.FriendRequestStatus == FriendRequestStatus.Pending).Count();
            return res;
        }

        public List<SocialUserViewModel> GetUserToRecSection() 
        {
            var currentUser = GetCurrent();
            if (currentUser == null) 
            {
                var model = _mapper.Map<List<SocialUserViewModel>>(_socialUserRepository.GetAll());
                return model;
            }

            var modelNoCurrent = _mapper.Map<List<SocialUserViewModel>>(_socialUserRepository.GetAll().Where(user => user.Id != currentUser.Id));
            return modelNoCurrent;
        }

    }
}
