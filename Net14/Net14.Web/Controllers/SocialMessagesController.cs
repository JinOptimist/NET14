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

namespace Net14.Web.Controllers
{
    public class SocialMessagesController : Controller

    {
        private SocialMessagesRepository _socialMessagesRepository;
        private UserService _userService;
        private IMapper _mapper;

        public SocialMessagesController(SocialMessagesRepository socialMessagesRepository,
            IMapper mapper, UserService userService)
        {
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
                    LastMessage = message
                    
                });
            }

            return View(dialogViewModels);
        }

    }
}
