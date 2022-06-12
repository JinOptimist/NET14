using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.Models;
using Net14.Web.Services;
using System;
using System.Collections.Generic;

namespace Net14.Web.Controllers
{
    public class SocialHubController : Controller
    {
        public UserService _userService;
        public IMapper _mapper;

        public SocialHubController(
            UserService userService, 
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult AllHub()
        {
            var user = _userService.GetCurrent();
            var friends = user.Friends;
            var friendsBirthdate = new List<UserSocial>();  // who has a birthday today or tomorrow 
            DateTime birthDate;
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            for (int i = 0; i < friends.Count; i++)
            {
                var currentFriend = friends[i];
                birthDate = currentFriend.BirthDate;
                if (birthDate.Day == tomorrow.Day && 
                    birthDate.Month == tomorrow.Month ||
                    birthDate.Day == today.Day &&
                    birthDate.Month == today.Month)
                {
                    friendsBirthdate.Add(currentFriend);
                }
            }
            var model = _mapper.Map<List<SocialUserViewModel>>(friendsBirthdate);

            return View(model);
        }
    }
}
