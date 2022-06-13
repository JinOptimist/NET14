using System;

namespace TeamLearningEnglish.Models
{
    public class TodayViewModel
    {
        public int Day { get; set; } = DateTime.Today.Day;
        public string Month { get; set; } = DateTime.Today.ToString("MMM");
        public int Year { get; set; } = DateTime.Today.Year;

    }
}
