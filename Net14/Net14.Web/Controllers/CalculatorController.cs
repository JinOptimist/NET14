using Microsoft.AspNetCore.Mvc;

namespace Net14.Web.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult StandardCalculator()
        {
            return View();
        }

        public IActionResult EngineeringCalculator()
        {
            return View();
        }

        public IActionResult FinancialCalculator()
        {
            return View();
        }
    }
}
