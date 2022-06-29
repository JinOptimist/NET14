using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TeamLearningEnglish.EfStuff;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.EfStuff.Repository;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.Controllers
{
    public class HomeController : Controller
    {
        private WordsRepository _wordsRepository;
        private WordCommentRepository _wordComment;
        private BooksRepository _booksRepository;
        private VideoNotesRepository _videoNotesRepository;

        public HomeController(
            WordsRepository wordsRepository,
            BooksRepository booksRepository,
            VideoNotesRepository videoNotesRepository,
            WordCommentRepository wordComment)
        {
            _wordsRepository = wordsRepository;
            _booksRepository = booksRepository;
            _videoNotesRepository = videoNotesRepository;
            _wordComment = wordComment;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Dictionary()
        {
            var dbModels = _wordsRepository.GetAll();

            var viewModels = dbModels
                .Select(dbModel => new WordsViewModel
                {
                    Id = dbModel.Id,
                    EnglishWord = dbModel.EnglishWord,
                    RussianWord = dbModel.RussianWord,
                    Rating = dbModel.Rating

                }).ToList();
            viewModels.Reverse();

            return View(viewModels);
        }
        public IActionResult AddWord(int wordId, string englishWord, string russianWord, int rating)
        {
            var dbModel = new WordDbModel
            {
                Id = wordId,
                EnglishWord = englishWord,
                RussianWord = russianWord,
                Rating = rating
            };

            _wordsRepository.Save(dbModel);

            return RedirectToAction("Dictionary");
        }
        public IActionResult RemoveWord(int id)
        {
            var dbModel = _wordsRepository.Get(id);
            _wordsRepository.Remove(dbModel);

            return RedirectToAction("Dictionary");
        }
        public IActionResult ShowWordComments(int wordId)
        {
            var wordDbModel = _wordsRepository.Get(wordId);
            var wordViewModel = new WordsViewModel
            {
                Id = wordDbModel.Id,
                EnglishWord = wordDbModel.EnglishWord,
                WordComments = wordDbModel.WordComments.Select(x => x.Text).ToList()
            };

            return View(wordViewModel);
        }
        public IActionResult AddWordComment(int wordId, string text)
        {
            var word = _wordsRepository.Get(wordId);

            var comment = new WordCommentDbModel()
            {
                Text = text,
                Word = word
            };
            _wordComment.Save(comment);

            return RedirectToAction("ShowWordComments", new { wordId = word.Id });
        }
        public IActionResult Video()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddVideoNote()
        {
            return RedirectToAction("Video");
        }
        [HttpPost]
        public IActionResult AddVideoNote(VideoNotesViewModel viewModel)
        {
            var dbModel = new VideoNotesDbModel
            {
                Text = viewModel.Text
            };

            _videoNotesRepository.Save(dbModel);

            return RedirectToAction("Video");
        }
        public IActionResult ShowMyNotes()
        {
            var dbModels = _videoNotesRepository.GetAll();
            var viewModels = dbModels.Select(dbModel => new VideoNotesViewModel
            {
                Id = dbModel.Id,
                Text = dbModel.Text
            }).ToList();

            viewModels.Reverse();

            return View(viewModels);
        }
        public IActionResult Books()
        {
            var dbModels = _booksRepository.GetAll();

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
            var dbModel = _booksRepository.Get(id);

            var viewModel = new BooksViewModel
            {
                Text = dbModel.Text
            };
            return View(viewModel);
        }
        public IActionResult Tests()
        {
            var wordsDb = _wordsRepository.GetAll();

            var wordsViewModels = wordsDb.Select(dbModel => new WordsViewModel
            {
                Id = dbModel.Id,
                EnglishWord = dbModel.EnglishWord,
                RussianWord = dbModel.RussianWord
            }).ToList();

            wordsViewModels.Reverse();

            return View(wordsViewModels);

        }


    }
}
