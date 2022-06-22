namespace TeamLearningEnglish.Models
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public UserViewModel Sender { get; set; }
        public UserViewModel Receiver { get; set; }

    }
}
