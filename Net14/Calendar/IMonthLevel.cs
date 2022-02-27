using System;
using System.Collections.Generic;
using System.Text;
using Calendar.Days;

namespace Calendar
{
    public interface IMonthLevel
    {
        int DaysInWeek { get; set; }
        int WeeksInMonth { get; set; }
        int DayNumber { get; set; }
        int MonthNumber { get; set; }
        int Year { get; set; }
        int WeekendsCount { get; set; }
        int WorkDaysCount { get; set; }
        string EmptyDays { get; set; }
        List<BaseDays> Month { get; set; }
        public void Scroll(DirectionForMonth left);
        public void ChangeDayType(BaseDays date);
    }
}
