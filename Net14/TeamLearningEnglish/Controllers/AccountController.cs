using AutoMapper;
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
        private UserService _userService;
        private IMapper _mapper;

        public AccountController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize]
        public IActionResult MyAccount()
        {
            var currentUser = _userService.GetCurrent();

            var userViewModel = _mapper.Map<UserViewModel>(currentUser);

            return View(userViewModel);
        }
        public IActionResult Calendar()
        {
            var today = new TodayViewModel();

            return View(today);
        }

    }
}
