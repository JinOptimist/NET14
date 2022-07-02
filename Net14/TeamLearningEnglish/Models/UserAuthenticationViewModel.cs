using static TeamLearningEnglish.Models.EnglishLevel;
using System.Collections.Generic;

namespace TeamLearningEnglish.Models
{
    public class UserAuthenticationViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }     
        public Level EnglishLevel { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
