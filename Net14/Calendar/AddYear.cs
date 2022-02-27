using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;

namespace Calendar
{
    public class AddYear
    {
        
        public void DrawYear(MonthLevel monthLevel)
        {
            var createCalendar = new CreateCalendar();
            var calendarDrawer = new CalendarDrawer();
            var oldMonth = monthLevel.MonthNumber;
            for (int i = 1; i <= 12; i++)
            {
                if (i <= 11)
                {
                    calendarDrawer.Draw(createCalendar.Create(monthLevel.DaysInWeek, monthLevel.WeeksInMonth, monthLevel.DayNumber,
                    monthLevel.EmptyDays, monthLevel.MonthNumber = i, monthLevel.Year, monthLevel.WeekendsCount));
                    if (monthLevel.WeeksInMonth >=5)
                    { Console.WriteLine(); }
                }
                monthLevel.MonthNumber = i;
                
            }

        }

    }
}

