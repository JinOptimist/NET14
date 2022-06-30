using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.EfStuff.Repository;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.Controllers
{
    public class DictionaryController : Controller
    {
        private WordsRepository _wordsRepository;
        private WordCommentRepository _wordComment;

        public DictionaryController(
            WordsRepository wordsRepository, 
            WordCommentRepository wordComment)
        {
            _wordsRepository = wordsRepository;
            _wordComment = wordComment;
        }

        public IActionResult Dictionary()
        {
            var dbModels = _wordsRepository.GetAll();

            var viewModels = dbModels
                .Select(dbModel => new WordViewModel
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
            var wordDbModel = _wordsRepository.Get(id);
            _wordsRepository.Remove(wordDbModel);

            return RedirectToAction("Dictionary");
        }
        public IActionResult ShowWordComments(int wordId)
        {
            var wordDbModel = _wordsRepository.Get(wordId);
            var wordViewModel = new WordViewModel
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
        public IActionResult Tests()
        {
            var wordsDb = _wordsRepository.GetAll();

            var wordsViewModels = wordsDb.Select(dbModel => new WordViewModel
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
