using Microsoft.AspNetCore.SignalR;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.SignalRHubs
{
    public class CalendarGlobalNotifications : Hub
    {
        private UserService _userService;

        public CalendarGlobalNotifications(UserService userService)
        {
            _userService = userService;
        }

        public void UserEntered()
        {
            var user = _userService.GetCurrent()?.FirstName ?? "Guest";
            Clients.All.SendAsync("UserEntered", user);
        }
        public void AdminsHello()
        {
            Clients.All.SendAsync("AdminsHello", "Hello");
        }
    }
}
