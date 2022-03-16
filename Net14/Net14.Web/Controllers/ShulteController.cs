using Microsoft.AspNetCore.Mvc;
using Net14.Web.Models.Shulte;
using System;
using System.Collections.Generic;

namespace Net14.Web.Controllers
{
    public class ShulteController : Controller
    {
        public IActionResult Main()
        {
            var random = new RandomNumberViewModel();
            var numbers = new List<int>(random.Random());
            return View(numbers);
        }
    }
}
