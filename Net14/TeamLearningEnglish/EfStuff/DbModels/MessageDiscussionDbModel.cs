using TeamLearningEnglish.EfStuff.DbModels;

namespace TeamLearningEnglish.Models
{
    public class MessageDiscussionDbModel : BaseModel
    {
        public string Text { get; set; }
        public virtual UserDbModel Sender { get; set; }
        public virtual DiscussionDbModel Discussion { get; set; }
    }
}


