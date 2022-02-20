using System;
using System.Collections.Generic;
using System.Text;
using Calendar.Days;

namespace Calendar
{
    public class MonthLevel : IMonthLevel
    {
        public int DaysInWeek { get; set; }
        public int WeeksInMonth { get; set; }
        public int DayNumber { get; set; }
        public string EmptyDays { get; set; }
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
