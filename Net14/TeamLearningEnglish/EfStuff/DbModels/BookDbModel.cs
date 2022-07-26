using TeamLearningEnglish.EfStuff.DbModels;

namespace TeamLearningEnglish.Models
{
    public class BookDbModel : BaseModel
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
