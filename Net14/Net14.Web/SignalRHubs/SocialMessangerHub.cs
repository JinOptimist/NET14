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
        private SocialUserRepository _socialUserRepository;
        private SocialMessagesRepository _socialMessagesRepository;
        private UserService _userService;

        public SocialMessangerHub(SocialMessagesRepository socialMessagesRepository, 
            SocialUserRepository socialUserRepository, UserService userService)
        {
            _userService = userService;
            _socialMessagesRepository = socialMessagesRepository;
            _socialUserRepository = socialUserRepository;
        }

        public void UserView(string userId) 
        {
            var currentUser = _userService.GetCurrent();
            var user = _socialUserRepository.Get(Int32.Parse(userId));
            var dbMessages = _socialMessagesRepository.GetMessagesOfTwoUsers(user.Id, currentUser.Id);

            dbMessages.ForEach(message =>
            {
                if (message.Reciever.Id == currentUser.Id)
                {
                    message.IsViewdByReciever = true;
                }
            });

            Clients.User(userId).SendAsync("MessagesAreViewed");
        }

        public void SendMessage(string message, string userId)
        {
            var messageModel = new SocialMessages()
            {
                Sender = _userService.GetCurrent(),
                Reciever = _socialUserRepository.Get(Int32.Parse(userId)),
                Text = message
            };

            _socialMessagesRepository.Save(messageModel);


            Clients.User(userId).SendAsync("RecievedMessage", message, messageModel.Date.ToShortTimeString());
            
        }
    }
}
