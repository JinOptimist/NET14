using Microsoft.AspNetCore.SignalR;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.SignalRHubs
{
    public class SocialMessangerHub : Hub
    {
        private UserService _userService;

        public SocialMessangerHub(UserService userService)
        {
            _userService = userService;
        }

        public void OneMoreClick()
        {
            Clients.All.SendAsync("OneMoreClick");
        }

        public void AddMessage(string message)
        {
            var name = _userService.GetCurrent()?.FirstName ?? "GUEST";
            Clients.All.SendAsync("AddMessage", message, name);
        }
    }
}
