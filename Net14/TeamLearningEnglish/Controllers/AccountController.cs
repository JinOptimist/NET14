using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult MyAccount()
        {
            return View();
        }
        public IActionResult Calendar()
        {
            var today = new TodayViewModel();

            return View(today);
        }

    }
}
