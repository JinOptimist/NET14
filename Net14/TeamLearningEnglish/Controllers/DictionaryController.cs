using AutoMapper;
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
        private WordCommentRepository _wordCommentRepository;
        private FolderWordRepository _folderRepository;
        private IMapper _mapper;

        public DictionaryController(
            WordsRepository wordsRepository,
            WordCommentRepository wordComment,
            FolderWordRepository folderRepository,
            IMapper mapper)
        {
            _wordsRepository = wordsRepository;
            _wordCommentRepository = wordComment;
            _folderRepository = folderRepository;
            _mapper = mapper;
        }
        public IActionResult Dictionary(DictionaryWordViewModel word)
        {
            if(word == null)
            {
                return View(word);
            }
            else
            {
                var dbModels = _folderRepository.GetAll();
                var viewModels = dbModels.Select(dbModel => new FolderWordViewModel
                {
                    Name = dbModel.Name
                }).ToList();
                var dictionary = new DictionaryWordViewModel
                {
                    AllFolders = viewModels.Select(x => x.Name).ToList()
                };
                return View(dictionary);
            }
        }
        public IActionResult ShowWords(string nameFolder)
        {
            var folderDbModel = _folderRepository.GetByName(nameFolder);

            var wordDbModels = folderDbModel.Words.ToList();

            var activeWords = wordDbModels.Where(x => x.isActive).ToList();

            var viewModels = activeWords
                .Select(dbModel => new WordViewModel
                {
                    Id = dbModel.Id,
                    EnglishWord = dbModel.EnglishWord,
                    RussianWord = dbModel.RussianWord,
                    Importance = dbModel.Importance
                }).ToList();
            viewModels.Reverse();

            return View(viewModels);
        }
        [HttpGet]
        public IActionResult AddWord()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWord(DictionaryWordViewModel word)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Dictionary", "Dictionary", word);
            }

            var folder = _folderRepository.GetByName(word.Folder);

            var dbModel = new WordDbModel
            {
                Id = word.Id,
                EnglishWord = word.EnglishWord.ToLower(),
                RussianWord = word.RussianWord.ToLower(),
                Folder = folder
            };

            _wordsRepository.Save(dbModel);

            return RedirectToAction("Dictionary");
        }
        public IActionResult RemoveWord(int id)
        {
            var wordDbModel = _wordsRepository.Get(id);
            wordDbModel.isActive = false;
            _wordsRepository.Save(wordDbModel);

            return RedirectToAction("Dictionary");
        }
        public IActionResult AddWordComment(int wordId, string text)
        {
            var word = _wordsRepository.Get(wordId);

            var comment = new WordCommentDbModel()
            {
                Text = text,
                Word = word
            };
            _wordCommentRepository.Save(comment);

            return RedirectToAction("ShowWordComments", new { wordId = word.Id });
        }
        public IActionResult ShowWordComments(int wordId)
        {
            var wordDbModel = _wordsRepository.Get(wordId);


            var wordViewModel = _mapper.Map<WordViewModel>(wordDbModel);

            return View(wordViewModel);
        }


    }
}
