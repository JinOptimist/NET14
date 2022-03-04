using Microsoft.AspNetCore.Mvc;

namespace Net14.Web.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
