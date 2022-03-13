using Microsoft.AspNetCore.Mvc;
using Net14.Web.Models.Shulte;
using System;
using System.Collections.Generic;

namespace Net14.Web.Controllers
{
    public class ShulteController : Controller
    {
        public IActionResult Main()
        {
            var number = new RandomNumberViewModel();
            var random = new Random();
            
                number.Number1 = random.Next(1, 25);
                number.Number2 = random.Next(1, 25);
                number.Number3 = random.Next(1, 25);
                number.Number4 = random.Next(1, 25);
                number.Number5 = random.Next(1, 25);
                number.Number6 = random.Next(1, 25);
                number.Number7 = random.Next(1, 25);
                number.Number8 = random.Next(1, 25);
                number.Number9 = random.Next(1, 25);
                number.Number10 = random.Next(1, 25);
                number.Number11 = random.Next(1, 25);
                number.Number12 = random.Next(1, 25);
                number.Number13 = random.Next(1, 25);
                number.Number14 = random.Next(1, 25);
                number.Number15 = random.Next(1, 25);
                number.Number16 = random.Next(1, 25);
                number.Number17 = random.Next(1, 25);
                number.Number18 = random.Next(1, 25);
                number.Number19 = random.Next(1, 25);
                number.Number20 = random.Next(1, 25);
                number.Number21 = random.Next(1, 25);
                number.Number22 = random.Next(1, 25);
                number.Number23 = random.Next(1, 25);
                number.Number24 = random.Next(1, 25);
            
            return View(number);
           
        }
    }
}
