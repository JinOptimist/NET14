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

namespace Net14.Web.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SocialMessagesController : ControllerBase

    {
        private SocialMessagesRepository _socialMessagesRepository;
        private SocialUserRepository _socialUserRepository;
        private UserService _userService;


        public SocialMessagesController(SocialMessagesRepository socialMessagesRepository,
               UserService userService, SocialUserRepository socialUserRepository)
        {
            _socialUserRepository = socialUserRepository;
            _socialMessagesRepository = socialMessagesRepository;
            _userService = userService;
        }

        [HttpPost]
        public bool SendMessage( SendMessageViewModel message) 
        {
            var messageModel = new SocialMessages()
            {
                Sender = _userService.GetCurrent(),
                Reciever = _socialUserRepository.Get(message.UserId),
                Text = message.Message
            };

            _socialMessagesRepository.Save(messageModel);

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
