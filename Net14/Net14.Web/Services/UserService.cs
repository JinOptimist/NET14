﻿using Microsoft.AspNetCore.Http;
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

namespace Net14.Web.Services
{
    public class UserService
    {
        private SocialUserRepository _socialUserRepository;
        private IHttpContextAccessor _httpContextAccessor;
        private IMapper _mapper;

        public UserService(
            SocialUserRepository socialUserRepository,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _socialUserRepository = socialUserRepository;
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

        public int GetUsersNotifications() 
        {
            var currentUser = GetCurrent();
            var recievedRequests = currentUser.FriendRequestReceived.Where(request => request.IsViewedByReceiver == false);
            var sentRequests = currentUser.FriendRequestSent
                .Where(request => request.FriendRequestStatus != FriendRequestStatus.Pending
                &&
                request.IsViewedBySender == false);



            return recievedRequests.Count() + sentRequests.Count();
        }
    }
}
