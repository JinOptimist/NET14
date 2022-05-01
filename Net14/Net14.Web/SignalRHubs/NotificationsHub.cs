using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.SignalRHubs
{
    [Authorize]
    public class NotificationsHub : Hub
    {
        private UserService _userService;

        public NotificationsHub(UserService userService) 
        {
            _userService = userService;
        }
        public void SendNotif(string message, string friendId)  
        {
            var currentUser = _userService.GetCurrent();
            Clients.User(friendId).SendAsync("SendNotif", $"{currentUser.FirstName} {currentUser.LastName} {message} friend request");
            return;
        }

    }
}
