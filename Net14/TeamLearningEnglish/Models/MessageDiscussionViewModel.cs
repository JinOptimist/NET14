using System.Collections.Generic;
using static TeamLearningEnglish.Models.EnglishLevel;

namespace TeamLearningEnglish.Models
{
    public class MessageDiscussionViewModel
    {
        public string Text { get; set; }
        public int SenderId { get; set; }
        public string DiscussionName { get; set; }

    }
}
