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

namespace Net14.Web.Controllers
{
    public class SocialMessagesController : Controller

    {
        private SocialMessagesRepository _socialMessagesRepository;
        private SocialUserRepository _socialUserRepository;
        private UserService _userService;
        private IMapper _mapper;
        private IHubContext<SocialMessangerHub> _messageHub;


        public SocialMessagesController(SocialMessagesRepository socialMessagesRepository,
            IMapper mapper, UserService userService, SocialUserRepository socialUserRepository,
            IHubContext<SocialMessangerHub> hubContext)
        {
            _socialUserRepository = socialUserRepository;
            _socialMessagesRepository = socialMessagesRepository;
            _userService = userService;
            _mapper = mapper;
            _messageHub = hubContext;
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
                var mes = _socialMessagesRepository.GetLastMessage(currentUser.Id, user.Id);

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

        public async Task<IActionResult> GetSingleDialog(int dialogFriendId)
        {
            var user = _socialUserRepository.Get(dialogFriendId);

            var userViewModel = _mapper.Map<SocialUserViewModel>(user);
            var currentUser = _userService.GetCurrent();

            var dbMessages = _socialMessagesRepository.GetMessagesOfTwoUsers(dialogFriendId, currentUser.Id);

            dbMessages.ForEach(message =>
            {
                if (message.Reciever.Id == currentUser.Id)
                {
                    message.IsViewdByReciever = true;
                }
            });

            _socialMessagesRepository.SaveList(dbMessages);

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

            await _messageHub.Clients.User(dialogFriendId.ToString()).SendAsync("MessagesAreViewed");



            return View(finalModel);
        }

    }
}
