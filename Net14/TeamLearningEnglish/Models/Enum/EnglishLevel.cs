using System.ComponentModel.DataAnnotations;

namespace TeamLearningEnglish.Models
{
    public class EnglishLevel
    {
        public enum Level
        {
            [Display(Name = "Begginer")]
            Begginer = 1,

            [Display(Name = "Elementary")]
            Elementary = 2,

            [Display(Name = "Pre Intermidiate")]
            PreIntermidiate = 4,

            [Display(Name = "Intermidiate")]
            Intermidiate = 8,

            [Display(Name = "Upper Intermidiate")]
            UpperIntermidiate = 16,

            [Display(Name = "Advanced")]
            Advanced = 32
        };

    }
}
