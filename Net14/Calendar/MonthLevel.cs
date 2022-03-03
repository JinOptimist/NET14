using System;
using System.Collections.Generic;
using System.Text;
using Calendar.Days;

namespace Calendar
{
    public class MonthLevel : IMonthLevel
    {
        public int DaysInWeek { get; set; } = 7;
        public int WeeksInMonth { get; set; } = 5;
        public int DayNumber { get; set; } = 1;
        public int MonthNumber { get; set; } = DateTime.Now.Month;
        public int Year { get; set; } = DateTime.Now.Year;
        public string EmptyDays { get; set; } = " ";
        public List<BaseDays> Month { get; set; }
        public void Scroll(DirectionForMonth left)
        {
            
            //<-,->,|^,.|
        }

        public void ChangeDayType(BaseDays date)
        {
            
            //work day => weekend, work day => holiday
        }
    }
}
