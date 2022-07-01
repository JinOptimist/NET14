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

        public DictionaryController(
            WordsRepository wordsRepository, 
            WordCommentRepository wordComment,
            FolderWordRepository folderRepository)
        {
            _wordsRepository = wordsRepository;
            _wordCommentRepository = wordComment;
            _folderRepository = folderRepository;
        }

        public IActionResult Dictionary()
        {
            var wordDbModels = _wordsRepository.GetAll();
            var activeWords = wordDbModels.Where(x => x.isActive).ToList();

            var allFolders = _folderRepository.GetAll();
            var folders = allFolders.Select(folder => folder.Name).ToList();

            var viewModels = activeWords
                .Select(dbModel => new WordViewModel
                {
                    Id = dbModel.Id,
                    EnglishWord = dbModel.EnglishWord,
                    RussianWord = dbModel.RussianWord,
                    Importance = dbModel.Importance,
                    Folder = dbModel.Folder.Name,
                    AllFolders = folders
                    
                }).ToList();
            
            
            viewModels.Reverse();

            return View(viewModels);
        }
        public IActionResult AddWord(int wordId, string englishWord, string russianWord, string folderName)
        {
            var folder = _folderRepository.GetByName(folderName);

            var dbModel = new WordDbModel
            {
                Id = wordId,
                EnglishWord = englishWord.ToLower(),
                RussianWord = russianWord.ToLower(),
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
            var wordViewModel = new WordViewModel
            {
                Id = wordDbModel.Id,
                EnglishWord = wordDbModel.EnglishWord,
                WordComments = wordDbModel.Comments.Select(x => x.Text).ToList()
            };

            return View(wordViewModel);
        }
        

    }
}
