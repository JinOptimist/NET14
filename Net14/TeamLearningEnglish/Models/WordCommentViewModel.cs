namespace TeamLearningEnglish.Models
{
    public class WordCommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual WordsViewModel Word { get; set; }
    }
}
