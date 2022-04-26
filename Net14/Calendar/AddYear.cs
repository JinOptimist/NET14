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
                if (i <= 12)
                {
                    calendarDrawer.Draw(createCalendar.Create(monthLevel.DaysInWeek, monthLevel.WeeksInMonth, monthLevel.DayNumber,
                    monthLevel.EmptyDays, monthLevel.MonthNumber = i, monthLevel.Year));
                    if (monthLevel.WeeksInMonth >=5)
                    { Console.WriteLine(); }
                }
                monthLevel.MonthNumber = i;
                
            }

        }
        public void AddCountForWeekendsAndWorkDaysInYear(MonthLevel monthLevel)
        {

            int daysInYear = 0;
            int weekendsCount = 0;
            for (int j = 1; j <= 12; j++)
            {
                int daysInMonth = DateTime.DaysInMonth(monthLevel.Year, j);
                
                for (int i = 1; i <= daysInMonth; i++)
                {
                    DateTime dt = new DateTime(monthLevel.Year, j, i);
                    if (dt.DayOfWeek.ToString() == "Saturday" || dt.DayOfWeek.ToString() == "Sunday")
                    {
                        weekendsCount++;
                    }
                    
                }
                daysInYear += daysInMonth;
            }
            Console.WriteLine($"In this year {weekendsCount} weekends and {daysInYear - weekendsCount} work days");
            Console.WriteLine(daysInYear);
        }

    }
}

