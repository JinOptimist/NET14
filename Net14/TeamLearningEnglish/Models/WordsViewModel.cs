using System.Collections.Generic;

namespace TeamLearningEnglish.Models
{
    public class WordsViewModel
    {
        public int Id { get; set; }
        public string EnglishWord { get; set; }
        public string RussianWord { get; set; }
        public int Rating { get; set; }
        public virtual List<WordCommentViewModel> WordComments { get; set; }
    }
}
