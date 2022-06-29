using TeamLearningEnglish.EfStuff.DbModels;

namespace TeamLearningEnglish.Models
{
    public class VideoNotesDbModel : BaseModel
    {
        public string VideoName { get; set; }
        public string Text { get; set; }
    }
}
