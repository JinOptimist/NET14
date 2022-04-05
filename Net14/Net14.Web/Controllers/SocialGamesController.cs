using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.Models.Shulte;
using System.Collections.Generic;

namespace Net14.Web.Controllers
{
    public class SocialGamesController : Controller
    {
        private WebContext _webContext;

        public SocialGamesController(WebContext webContext)
        {
            _webContext = webContext;
        }
        public IActionResult Main()
        {
            var random = new RandomNumberViewModel();
            var numbers = new List<int>(random.Random());
            return View(numbers);
        }
    }
}
