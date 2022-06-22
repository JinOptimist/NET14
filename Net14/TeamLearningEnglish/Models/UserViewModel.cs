using static TeamLearningEnglish.Models.EnglishLevel;
using System.Collections.Generic;

namespace TeamLearningEnglish.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }     
        public Level EnglishLevel { get; set; }
        public List<MessageViewModel> Messages { get; set; }

    }
}
