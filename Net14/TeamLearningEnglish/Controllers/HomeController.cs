using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TeamLearningEnglish.EfStuff;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.Controllers
{
    public class HomeController : Controller
    {
        private WebDbContext _webContext;

        public HomeController(WebDbContext webContext)
        {
            _webContext = webContext;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Dictionary()
        {
            var dbModels = _webContext.Words.ToList();

            var viewModels = dbModels.Select(dbModel => new WordsViewModel
            {
                Id = dbModel.Id,
                EnglishWord = dbModel.EnglishWord,
                RussianWord = dbModel.RussianWord,
                Rating = dbModel.Rating

            }).ToList();
            viewModels.Reverse();

            return View(viewModels);
        }
        public IActionResult AddWord(int id, string englishWord, string russianWord, int rating) 
        {
            var dbModel = new WordsDbModel
            {
                Id = id,
                EnglishWord = englishWord,
                RussianWord = russianWord,
                Rating = rating
            };
            _webContext.Words.Add(dbModel);
            _webContext.SaveChanges();

            return RedirectToAction("Dictionary");
        }
        public IActionResult RemoveWord(int id)
        {
            var dbModel = _webContext.Words.SingleOrDefault(x => x.Id == id);
            _webContext.Remove(dbModel);
            _webContext.SaveChanges();

            return RedirectToAction("Dictionary");
        }
        public IActionResult Video()
        {
            return View();
        }
        public IActionResult Books()
        {
            var dbModels = _webContext.Books.ToList();

            var viewModels = dbModels.Select(dbModel => new BooksViewModel
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                Text = dbModel.Text
            }).ToList();

            return View(viewModels);
        }
        public IActionResult ShowBook(int id)
        {
            var dbModel = _webContext.Books.First(x => x.Id == id);

            var viewModel = new BooksViewModel
            {
                Text = dbModel.Text
            };
            return View(viewModel);
        }


    }
}
