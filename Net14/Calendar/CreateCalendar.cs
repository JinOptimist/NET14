using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Channels;
using Calendar.Days;
using Microsoft.VisualBasic;

namespace Calendar
{
    public class CreateCalendar
    {
        private MonthLevel monthLevel;
        
        public MonthLevel Create(int year, int month, int daysInWeek = 7, int weeksInMonth = 5, int dayNumber = 1, string emptyDays = " " )
        {
            monthLevel = CreateCurrentMonth(daysInWeek, weeksInMonth, dayNumber, emptyDays);
            
            CurrentCal(year, month);
            

            return monthLevel;
        }

        
        public MonthLevel CreateCurrentMonth(int daysInWeek, int weeksInMonth, int dayNumber, string emptyDays)
        {
            var monthLevel = new MonthLevel();
            monthLevel.DaysInWeek = daysInWeek;
            monthLevel.WeeksInMonth = weeksInMonth;
            monthLevel.DayNumber = dayNumber;
            monthLevel.EmptyDays = emptyDays;
            monthLevel.Month = new List<BaseDays>();
            return monthLevel;
        }

        private void CurrentCal(int year, int month)
        {
            int count = 0;
            int EmptyDay = 0;
            var emptyDay = new EmptyDay(monthLevel)
            {
                Symbol = " "
            };
            int daysCount = DateTime.DaysInMonth(year, month);
            var firstDayOfMonth = new DateTime(year, month, 1).DayOfWeek;
            switch (firstDayOfMonth.ToString())
            {
                
                case "Monday":
                    break;
                case "Tuesday":
                    monthLevel.Month.Add(emptyDay);
                    EmptyDay = 1;
                    break;
                case "Wednesday":
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    EmptyDay = 2;
                    break;
                case "Thursday":
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    EmptyDay = 3;
                    break;
                case "Friday":
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    EmptyDay = 4;
                    break;
                case "Saturday":
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    EmptyDay = 5;
                    break;
                case "Sunday":
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    EmptyDay = 6;
                    break;
                default:
                    EmptyDay = 0;
                    break;
            }

            
            for (int y = 0; y < (daysCount+EmptyDay)/7+1; y++)
            {
                for (int x = 0; x < monthLevel.DaysInWeek; x++)
                {
                    if (count == daysCount+EmptyDay)
                    {break;}
                    
                    var date = new Day(monthLevel)
                    {
                        X = x,
                        Y = y,
                        Symbol = monthLevel.DayNumber.ToString(),
                        
                    };
                    if (EmptyDay <= count)
                    {
                        monthLevel.DayNumber++;
                    }
                    count++;

                    monthLevel.Month.Add(date);
                }
            }
        }

    }
}
