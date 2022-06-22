using TeamLearningEnglish.EfStuff.DbModels;

namespace TeamLearningEnglish.Models
{
    public class MessageDbModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public UserDbModel Sender { get; set; }
        public UserDbModel Receiver { get; set; }

    }
}
