using System.Collections.Generic;

namespace TeamLearningEnglish.EfStuff.DbModels
{
    public class WordDbModel : BaseModel
    {
        public string EnglishWord { get; set; }
        public string RussianWord { get; set; }
        public int Importance { get; set; } = 5;
        public virtual List<WordCommentDbModel> WordComments { get; set; }
    }
}
