using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Net14.Web.Controllers
{
    public class CalendarController : Controller
    {
        private WebContext _webContext;

        public CalendarController(WebContext webContext)
        {
            _webContext = webContext;
        }
        public IActionResult Index()
        {
            var model = new List<string>() { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            foreach (var item in model)
            {
                View(item);
            }
            return View(model);
        }
       
    }
}
