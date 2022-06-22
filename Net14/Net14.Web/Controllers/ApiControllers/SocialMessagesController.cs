using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.Repositories;
using Microsoft.AspNetCore.Authorization;
using Net14.Web.Services;
using AutoMapper;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Net14.Web.Controllers.AutorizeAttribute;
using Net14.Web.Models.SocialModels.Enums;
using Net14.Web.SignalRHubs;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using Net14.Web.Models.SocialModels.Attributes;

namespace Net14.Web.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    [SocialAPI]

    public class SocialMessagesController : ControllerBase

    {
        private SocialMessagesRepository _socialMessagesRepository;
        private SocialUserRepository _socialUserRepository;
        private UserService _userService;
        private IHubContext<NotificationsHub> _hubContext;

        public SocialMessagesController(SocialMessagesRepository socialMessagesRepository,
               UserService userService, SocialUserRepository socialUserRepository, IHubContext<NotificationsHub> hub)
        {
            _hubContext = hub;
            _socialUserRepository = socialUserRepository;
            _socialMessagesRepository = socialMessagesRepository;
            _userService = userService;
        }

        [HttpPost]
        public bool SendMessage(SendMessageViewModel message) 
        {
            var sender = _userService.GetCurrent();
            var messageModel = new SocialMessages()
            {
                Sender = sender,
                Reciever = _socialUserRepository.Get(message.UserId),
                Text = message.Message
            };

            _socialMessagesRepository.Save(messageModel);

            _hubContext.Clients.User(message.UserId.ToString()).SendAsync("SendMessageNotificaton", message.Message, $"{sender.FirstName} {sender.LastName}", sender.UserPhoto, sender.Id.ToString());

            return true;
        }

        public void ViewMessage(int userId) 
        {
            var currentUser = _userService.GetCurrent();

            var messages = _socialMessagesRepository
                .GetMessagesOfTwoUsers(currentUser.Id, userId)
                .Where(message => !message.IsViewdByReciever)
                .ToList();

            messages.ForEach(message => message.IsViewdByReciever = true);

            _socialMessagesRepository.SaveList(messages);
        }
    }
}
