using System.Collections.Generic;
using TeamLearningEnglish.EfStuff.DbModels;

namespace TeamLearningEnglish.Models
{
    public class DiscussionDbModel : BaseModel
    {
        public string Name { get; set; }
        public virtual UserDbModel Creator { get; set; }
        public virtual List<UserDbModel> Users { get; set; }
        public virtual List<MessageDiscussionDbModel> Messages { get; set; }
    }
}
