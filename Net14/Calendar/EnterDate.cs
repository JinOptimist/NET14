using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Calendar
{
    public class EnterDate
    {
        public DateTime Date()
        {
            DateTime checkDate;
            string input;

            do
            {
                Console.WriteLine("Введите дату в формате дд.ММ.гггг:");
                input = Console.ReadLine();
            }
            while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out checkDate));

            return checkDate;
        }
    }
}
