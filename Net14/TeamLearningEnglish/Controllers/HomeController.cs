using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Dictionary()
        {
            var models = new List<WordsViewModel>()
            {
                new WordsViewModel
                {
                    Id = 1,
                    EnglishWord = "apple",
                    RussianWord = "яблоко",
                    Rating = 2
                },
                new WordsViewModel
                {
                    Id = 1,
                    EnglishWord = "car",
                    RussianWord = "машина",
                    Rating = 5
                },
                new WordsViewModel
                {
                    Id = 1,
                    EnglishWord = "book",
                    RussianWord = "книга",
                    Rating = 15
                }
            };
            return View(models);
        }
        public IActionResult Video()
        {
            return View();
        }
        public IActionResult Books()
        {
            return View();
        }


    }
}
