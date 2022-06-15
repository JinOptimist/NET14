namespace TeamLearningEnglish.EfStuff.DbModels
{
    public class WordsDbModel
    {
        public int Id { get; set; }
        public string EnglishWord { get; set; }
        public string RussianWord { get; set; }
        public int Rating { get; set; }
    }
}
