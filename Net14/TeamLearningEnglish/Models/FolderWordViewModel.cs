using System.Collections.Generic;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff.DbModels
{
    public class FolderWordViewModel
    {
        public string Name { get; set; }
        public int Passed { get; set; }
        public List<string> Words { get; set; }
    }
}
