using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using Microsoft.VisualBasic;

namespace Calendar
{
    public class CreateCalendar
    {
        
        public void Spawn()
        {
            int Month = 0;
            int Year = 0;
            Month = DateTime.Now.Month;
            Year = DateTime.Now.Year;
            var EmptyDay = 0;
            List<string> DayOfWeek = new List<string>() {"Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"};
            foreach (var DayW in DayOfWeek)
            {
                Console.Write($"{DayW}\t");
            }
            List<string> DaysOfMonth = new List<string>();
            var FirstDayOfMonth = new DateTime(Year, Month, 1).DayOfWeek;
            
            switch (FirstDayOfMonth.ToString())
            {
                case "Monday":
                    break;
                case "Tuesday":
                    DaysOfMonth.Add(" ");
                    EmptyDay = 1;
                    break;
                case "Wednesday":
                    DaysOfMonth.Add(" ");
                    DaysOfMonth.Add(" ");
                    EmptyDay = 2;
                    break;
                case "Thursday":
                    DaysOfMonth.Add(" ");
                    DaysOfMonth.Add(" ");
                    DaysOfMonth.Add(" ");
                    EmptyDay = 3;
                    break;
                case "Friday":
                    DaysOfMonth.Add(" ");
                    DaysOfMonth.Add(" ");
                    DaysOfMonth.Add(" ");
                    DaysOfMonth.Add(" ");
                    EmptyDay = 4;
                    break;
                case "Saturday":
                    DaysOfMonth.Add(" ");
                    DaysOfMonth.Add(" ");
                    DaysOfMonth.Add(" ");
                    DaysOfMonth.Add(" ");
                    DaysOfMonth.Add(" ");
                    EmptyDay = 5;
                    break;
                case "Sunday":
                    DaysOfMonth.Add(" ");
                    DaysOfMonth.Add(" ");
                    DaysOfMonth.Add(" ");
                    DaysOfMonth.Add(" ");
                    DaysOfMonth.Add(" ");
                    DaysOfMonth.Add(" ");
                    EmptyDay = 6;
                    break;
                default:
                    EmptyDay = 0;
                    break;
            }


            Console.WriteLine();
            int Index = 0;
            int Day = 1;
            int DaysCount = DateTime.DaysInMonth(Year, Month);
            while (Index <= DaysCount+EmptyDay)
            {
                DaysOfMonth.Add(Day.ToString());
                Index++;
                Day++;
            }
            int count = 0;
            for (double i = 0; i <= (DaysCount+EmptyDay) / 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (count == (DaysCount+EmptyDay))
                    { break; }
                    Console.Write($"{DaysOfMonth[count]}\t");
                    count++;
                }

                Console.WriteLine();
            }

        }

    }
}
