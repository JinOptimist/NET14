using Microsoft.AspNetCore.Mvc;
using Net14.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            var model = new GalleryIndexViewModel();

            model.DayOfWeek = (int)DateTime.Now.DayOfWeek;
            model.Seconds = DateTime.Now.Second;
            model.MonthName = DateTime.Now.ToString("MMM");

            return View(model);
        }
    }
}
