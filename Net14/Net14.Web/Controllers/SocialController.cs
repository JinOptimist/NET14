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

        public IActionResult ShowSecnodIndex() 
        {
            return View();
        }

        public IActionResult Settings() 
        {
            return View();
        }
        public IActionResult ShowAllUsers() 
        {
            return View();
        }

    }
}
