using Microsoft.AspNetCore.SignalR;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.EfStuff.DbModel.SocialDbModels;

namespace Net14.Web.SignalRHubs
{
    public class SocialMessangerHub : Hub
    {
        private UserService _userService;

        public SocialMessangerHub(SocialMessagesRepository socialMessagesRepository, 
            SocialUserRepository socialUserRepository, UserService userService)
        {
            _userService = userService;
        }

        public void SendMessage(string message, string userId)
        {
            Clients.User(userId).SendAsync("RecievedMessage", message, DateTime.Now.ToShortTimeString());   
        }

        public void MessagesAreViewed(string dialogFriendId) 
        {
            Clients.User(dialogFriendId.ToString()).SendAsync("MessagesAreViewed");
        }
    }
}
