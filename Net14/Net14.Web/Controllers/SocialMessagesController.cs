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

namespace Net14.Web.Controllers
{
    public class SocialMessagesController : Controller

    {
        private SocialMessagesRepository _socialMessagesRepository;
        private SocialUserRepository _socialUserRepository;
        private UserService _userService;
        private IMapper _mapper;

        public SocialMessagesController(SocialMessagesRepository socialMessagesRepository,
            IMapper mapper, UserService userService, SocialUserRepository socialUserRepository)
        {
            _socialUserRepository = socialUserRepository;
            _socialMessagesRepository = socialMessagesRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult GetDialogs()
        {
            List<UserDialogViewModel> dialogViewModels = new List<UserDialogViewModel>();
            var currentUser = _userService.GetCurrent();
            var currentUserViewModel = _mapper.Map<SocialUserViewModel>(currentUser);

            var recievedMessagesUsers = currentUser.RecievedMessages
                .Select(user =>
                user.Sender).ToList();

            var sentMessagesUsers = currentUser.SendMessages
                .Select(user =>
                user.Reciever).ToList();

            var dialogsUsers = recievedMessagesUsers.Union(sentMessagesUsers).ToList();

            foreach (var user in dialogsUsers)
            {
                var mes = _socialMessagesRepository
                    .GetAll()
                    .Where(message => message.Sender == currentUser && message.Reciever == user
                    || message.Reciever == currentUser && message.Sender == user).OrderByDescending(message => message.Date).First();

                var message = _mapper.Map<SocialMessageViewModel>(mes);

                dialogViewModels.Add(new UserDialogViewModel()
                {
                    CurrentUser = currentUserViewModel,
                    User = _mapper.Map<SocialUserViewModel>(user),
                    LastMessage = message,
                    LastMessageType = message.Sender.Id == currentUserViewModel.Id ? MessageType.Sent : MessageType.Recieved

                });

            }

            return View(dialogViewModels);
        }

        public IActionResult GetSingleDialog(int dialogFriendId)
        {
            var user = _socialUserRepository.Get(dialogFriendId);

            var userViewModel = _mapper.Map<SocialUserViewModel>(user);
            var currentUser = _userService.GetCurrent();

            var dbMessages = _socialMessagesRepository
                .GetAll()
                .Where(message => message.Sender == user && message.Reciever == currentUser
                        ||
                        message.Reciever == user && message.Sender == currentUser).ToList();

            var messagesViewModel = _mapper.Map<List<SocialMessageViewModel>>(dbMessages);

            messagesViewModel.ForEach(message =>
            {
                if (message.Sender.Id == _mapper.Map<SocialUserViewModel>(currentUser).Id)
                {
                    message.MessageType = MessageType.Sent;
                }
                else
                {
                    message.MessageType = MessageType.Recieved;
                }
            });

            var finalModel = new SocialMessageWithUserViewModel()
            {
                Messages = messagesViewModel,
                UserOfDialog = userViewModel
            };
            
            return View(finalModel);
        }

    }
}
