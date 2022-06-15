using static TeamLearningEnglish.Models.EnglishLevel;

namespace TeamLearningEnglish.EfStuff.DbModels
{
    public class UserDbModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Level EnglishLevel { get; set; }

    }
}
