using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeamLearningEnglish.EfStuff.DbModels;

namespace TeamLearningEnglish.Models
{
    public class DictionaryWordViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter English word")]
        [RegularExpression(@"^[a-zA-Z\s]*$",ErrorMessage ="Введите слово на Английском")]
        public string EnglishWord { get; set; }
        [Required(ErrorMessage ="Enter Russian word")]
        [RegularExpression(@"^[а-яА-Я\s]*$", ErrorMessage = "Введите слово на Русском")]
        public string RussianWord { get; set; }
        public int Importance { get; set; }
        public string Folder { get; set; }
        public List<string> AllFolders { get; set; }
        public List<string> WordComments { get; set; }
        public virtual List<WordViewModel> Words { get; set; }
    }
}
