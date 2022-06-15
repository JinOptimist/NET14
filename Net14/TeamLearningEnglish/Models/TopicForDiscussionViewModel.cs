using static TeamLearningEnglish.Models.EnglishLevel;

namespace TeamLearningEnglish.Models
{
    public class TopicForDiscussionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatorName { get; set; }
        public int Rating { get; set; }
    }
}
