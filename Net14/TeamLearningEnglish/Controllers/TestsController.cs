using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TeamLearningEnglish.EfStuff.Repository;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.Controllers
{
    public class TestsController : Controller
    {
        private WordsRepository _wordsRepository;

        public TestsController(WordsRepository wordsRepository)
        {
            _wordsRepository = wordsRepository;
        }

        public IActionResult ChoiceTest()
        {
            return View();
        }
        public IActionResult WordsTest()
        {
            var wordsDb = _wordsRepository.GetAll();
            var activeWords = wordsDb.Where(x => x.isActive == true).Where(x => x.Importance > 0);

            var wordsViewModels = activeWords.Select(dbModel => new WordViewModel
            {
                Id = dbModel.Id,
                EnglishWord = dbModel.EnglishWord,
                RussianWord = dbModel.RussianWord
            }).ToList();
            wordsViewModels.Reverse();

            return View(wordsViewModels);

        }
        public IActionResult CheckWordResult(string text, int wordId)
        {
            var word = _wordsRepository.Get(wordId);
            if(text.ToLower() == word.RussianWord)
            {
                word.Importance--;
            }
            if(word.Importance == 0)
            {
                word.isActive = false;
            }

            _wordsRepository.Save(word);

            return RedirectToAction("WordsTest");
        }
    }
}
