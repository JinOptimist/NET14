using System.Collections.Generic;

namespace TeamLearningEnglish.EfStuff.DbModels
{
    public class WordDbModel : BaseModel
    {
        public string EnglishWord { get; set; }
        public string RussianWord { get; set; }
        public int Rating { get; set; }
        public virtual List<WordCommentDbModel> WordComments { get; set; }
    }
}
