using System.Collections.Generic;
using TeamLearningEnglish.EfStuff.DbModels;

namespace TeamLearningEnglish.Models
{
    public class TestWordViewModel
    {
        public int Id { get; set; }
        public bool? Answer { get; set; }
        public List<WordViewModel> Words { get; set; }
    }
}
