using TeamLearningEnglish.EfStuff.DbModels;

namespace TeamLearningEnglish.Models
{
    public class MessageDbModel : BaseModel
    {
        public string Text { get; set; }
        public virtual UserDbModel Sender { get; set; }
        public virtual UserDbModel Receiver { get; set; }

    }
}
