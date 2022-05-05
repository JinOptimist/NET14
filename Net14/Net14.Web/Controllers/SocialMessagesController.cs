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
            var currentUser = _userService.GetCurrent();

            var recievedMessagesUsers = currentUser.RecievedMessages
                .Select(user =>
                user.Sender).ToList();


            var sentMessagesUsers = currentUser.SendMessages
                .Select(user =>
                user.Reciever).ToList();

            var dialogsUsers = recievedMessagesUsers.Union(sentMessagesUsers).ToList();

            return Json(messages);
        }

    }
}
