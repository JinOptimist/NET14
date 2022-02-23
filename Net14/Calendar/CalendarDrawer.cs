using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Calendar.Days;

namespace Calendar
{
    public class CalendarDrawer 
    {
        
        public void Draw(MonthLevel monthLevel)
        {
            Console.Clear();
            Console.WriteLine($"{AddCurrentMonthUp(monthLevel)}, {monthLevel.Year}");
            AddDaysOfWeek();
            Console.WriteLine();
            var emptyDay = AddEmptyDays(monthLevel);

            int count = 0;
            for (int yIndex = 0; yIndex < monthLevel.WeeksInMonth+1; yIndex++)
            {
                for (int xIndex = 0; xIndex < monthLevel.DaysInWeek; xIndex++)
                {
                    if (count >= DateTime.DaysInMonth(monthLevel.Year, monthLevel.MonthNumber)+emptyDay)
                    {break;}
                    var date = monthLevel.Month
                        .First(date => date.X == xIndex && date.Y == yIndex);
                    DrawDate(date);
                    count++;
                }
                Console.WriteLine();
            }
        }

        private void DrawDate(BaseDays date)
        {
            var oldColor = Console.ForegroundColor;
            var oldBackColor = Console.BackgroundColor;

            Console.ForegroundColor = date.Color;
            Console.BackgroundColor = date.BackColor;
            Console.Write($"{date.Symbol}\t");
            Console.ForegroundColor = oldColor;
            Console.BackgroundColor = oldBackColor;
        }
        private void AddDaysOfWeek()
        {
            List<string> DayOfWeek = new List<string>() { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            foreach (var DayW in DayOfWeek)
            {
                Console.Write($"{DayW}\t");
            }
        }

        private string AddCurrentMonthUp(MonthLevel monthLevel)
        {
            var Monthes = new Dictionary<int, string>()
            {
                {1, "January"},
                {2, "February"},
                {3, "March"},
                {4, "April"},
                {5, "May"},
                {6, "June"},
                {7, "July"},
                {8, "August"},
                {9, "September"},
                {10, "October"},
                {11, "November"},
                {12, "December"}
            };
            return Monthes[monthLevel.MonthNumber];
        }

        private int AddEmptyDays(MonthLevel monthLevel)
        {
            string DayOfWeek = new DateTime(monthLevel.Year, monthLevel.MonthNumber, 1).DayOfWeek.ToString();
            var emptyDays = new Dictionary<string, int>()
            {
                {"Monday", 0},
                {"Tuesday",1},
                {"Wednesday",2},
                {"Thursday",3},
                {"Friday",4},
                {"Saturday",5},
                {"Sunday",6}
            };
            return emptyDays[DayOfWeek];
        }
    }
}
