namespace TeamLearningEnglish.EfStuff.DbModels
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public bool isActive { get; set; } = true;
    }
}
