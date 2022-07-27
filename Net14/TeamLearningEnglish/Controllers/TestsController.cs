using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.EfStuff.Repository;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.Controllers
{
    public class TestsController : Controller
    {
        private WordsRepository _wordsRepository;
        private FolderWordRepository _folderRepository;

        public TestsController(
            WordsRepository wordsRepository, 
            FolderWordRepository folderRepository)
        {
            _wordsRepository = wordsRepository;
            _folderRepository = folderRepository;
        }

        public IActionResult ChoiceTest()
        {
            return View();
        }
        public IActionResult FoldersWord()
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
        public IActionResult TestWords(string nameFolder, bool? answer)
        {
            var folder = _folderRepository.GetByName(nameFolder);
            var wordsDb = folder.Words;
            var activeWords = wordsDb.Where(x => x.isActive == true).Where(x => x.Importance > 0);

            var wordsViewModels = activeWords.Select(dbModel => new WordViewModel
            {
                Id = dbModel.Id,
                EnglishWord = dbModel.EnglishWord,
                RussianWord = dbModel.RussianWord
            }).ToList();
            wordsViewModels.Reverse();

            var testWord = new TestWordViewModel();
            testWord.Words = wordsViewModels;
            testWord.Answer = answer;

            return View(testWord);
        }
        public IActionResult CheckWordResult(string text, int wordId)
        {
            bool answer = true;
            var word = _wordsRepository.Get(wordId);
            if(text.ToLower() == word.RussianWord)
            {
                word.Importance--;
                answer = true;
            }
            if(word.Importance == 0)
            {
                word.isActive = false;
            }

            _wordsRepository.Save(word);

            return RedirectToAction("TestWords", new {nameFolder = word.Folder.Name.ToString(), answer = answer });
        }
    }
}
