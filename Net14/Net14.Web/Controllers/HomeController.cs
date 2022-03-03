using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Net14.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = 1;
            model++;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
