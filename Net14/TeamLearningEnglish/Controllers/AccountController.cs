using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TeamLearningEnglish.EfStuff.Repository;
using TeamLearningEnglish.Models;
using TeamLearningEnglish.Services;

namespace TeamLearningEnglish.Controllers
{
    public class AccountController : Controller
    {
        public UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        public IActionResult MyAccount()
        {
            var currentUser = _userService.GetCurrent();

            var userViewModel = new UserViewModel
            {
                Id = currentUser.Id,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Age = currentUser.Age,
                EnglishLevel = currentUser.EnglishLevel
            };

            return View(userViewModel);
        }
        public IActionResult Calendar()
        {
            var today = new TodayViewModel();

            return View(today);
        }

    }
}
