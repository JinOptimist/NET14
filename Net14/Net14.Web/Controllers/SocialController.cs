using Microsoft.AspNetCore.Mvc;
using Net14.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Controllers
{
    public class SocialController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
