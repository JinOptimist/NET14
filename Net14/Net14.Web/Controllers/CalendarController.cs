using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;

namespace Net14.Web.Controllers
{
    public class CalendarController : Controller
    {
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
