using Microsoft.AspNetCore.Mvc;

namespace Net14.Web.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
