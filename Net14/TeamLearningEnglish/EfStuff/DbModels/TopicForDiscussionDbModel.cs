namespace TeamLearningEnglish.EfStuff.DbModels
{
    public class TopicForDiscussionDbModel : BaseModel
    {
        public string Name { get; set; }
        public string CreatorName { get; set; }
        public int Rating { get; set; }
    }
}
