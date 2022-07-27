﻿using System.Collections.Generic;
using static TeamLearningEnglish.Models.EnglishLevel;

namespace TeamLearningEnglish.Models
{
    public class IndexDiscussionViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatorName { get; set; }
        public virtual List<UserViewModel> Users { get; set; }
        public List<string> Messages { get; set; }
        public virtual List<DiscussionViewModel> Discussions { get; set; }

    }
}
