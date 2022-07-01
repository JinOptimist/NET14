using System.Collections.Generic;

namespace TeamLearningEnglish.EfStuff.DbModels
{
    public class FolderWordDbModel : BaseModel
    {
        public string Name { get; set; }
        public int Passed { get; set; }
        public virtual List<WordDbModel> Words { get; set; } = new List<WordDbModel>();
    }
}
