﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Net14.Web.EfStuff.Repositories;
using System.Threading.Tasks;

namespace Net14.Web.SignalRHubs
{
    [Authorize]
    public class NotificationsHub : Hub
    {
        private UserService _userService;
        private SocialUserRepository _userRepository;

        public NotificationsHub(UserService userService,
            SocialUserRepository socialUserRepository) 
        {
            _userRepository = socialUserRepository;
            _userService = userService;
        }
        public void SendNotif(string message, string friendId)  
        {
            var currentUser = _userService.GetCurrent();
            Clients.User(friendId).SendAsync("SendNotif", $"{currentUser.FirstName} {currentUser.LastName} {message} friend request", currentUser.UserPhoto);
        }

/*        public void SendMessageNotificaton(string message, string userId)
        {
            var currentUser = _userService.GetCurrent();
            Clients.User(userId).SendAsync("MessageNotification", message, $"{currentUser.FirstName} {currentUser.LastName}", currentUser.UserPhoto, currentUser.Id.ToString());
        }*/

    }
}
