namespace TeamLearningEnglish.EfStuff.DbModels
{
    public class WordCommentDbModel : BaseModel
    {
        public string Text { get; set; }
        public virtual WordDbModel Word { get; set; } 
    }
}
