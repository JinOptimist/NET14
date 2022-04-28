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
        public MonthLevel Create(int daysInWeek, int weeksInMonth, int dayNumber,
            string emptyDays, int monthNumber, int year)
        {
            monthLevel = CreateCurrentMonth(daysInWeek, weeksInMonth, dayNumber, emptyDays, monthNumber, year);
            
            CurrentCal(monthLevel);
            
            return monthLevel;
        }
        private MonthLevel CreateCurrentMonth(int daysInWeek, int weeksInMonth, int dayNumber,
            string emptyDays, int monthNumber, int year)
        {
            var monthLevel = new MonthLevel();
            monthLevel.DaysInWeek = daysInWeek;
            monthLevel.WeeksInMonth = weeksInMonth;
            monthLevel.DayNumber = dayNumber;
            monthLevel.EmptyDays = emptyDays;
            monthLevel.MonthNumber = monthNumber;
            monthLevel.Year = year;
            monthLevel.Month = new List<BaseDays>();
            return monthLevel;
        }

        private void CurrentCal(MonthLevel monthLevel)
        {
            int count = 0;
            int emptyDayCount = 0;
            var emptyDay = new EmptyDay(monthLevel)
            {
                Symbol = " "
            };
            int daysCount = DateTime.DaysInMonth(monthLevel.Year,monthLevel.MonthNumber );
            var firstDayOfMonth = new DateTime(monthLevel.Year, monthLevel.MonthNumber, 1).DayOfWeek;
            switch (firstDayOfMonth.ToString())
            {
                case "Monday":
                    break;
                case "Tuesday":
                    monthLevel.Month.Add(emptyDay);
                    emptyDayCount = 1;
                    break;
                case "Wednesday":
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    emptyDayCount = 2;
                    break;
                case "Thursday":
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    emptyDayCount = 3;
                    break;
                case "Friday":
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    emptyDayCount = 4;
                    break;
                case "Saturday":
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    emptyDayCount = 5;
                    break;
                case "Sunday":
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    monthLevel.Month.Add(emptyDay);
                    emptyDayCount = 6;
                    break;
                default:
                    emptyDayCount = 0;
                    break;
            }
            for (int y = 0; y < (daysCount+emptyDayCount)/7+1; y++)
            {
                for (int x = 0; x < monthLevel.DaysInWeek; x++)
                {
                    if (count == daysCount+emptyDayCount)
                    {break;}
                    var date = new Day(monthLevel)
                    {
                        X = x,
                        Y = y,
                        Symbol =  monthLevel.DayNumber.ToString(),
                        Color = ConsoleColor.White
                    };
                    if (x > 4)
                    {
                        date = new Day(monthLevel)
                        {
                            X = x,
                            Y = y,
                            Symbol = monthLevel.DayNumber.ToString(),
                            Color = ConsoleColor.Red
                        };
                    }
                    if (emptyDayCount > count)
                    {
                        date = new Day(monthLevel)
                        {
                            X = x,
                            Y = y,
                            Symbol = " "
                        };
                    }
                    if (emptyDayCount <= count)
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
