using Calendar.Days;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Calendar
{
    public class EnterDate
    {
        
        
        public DateTime Date(string mess)
        {
            DateTime checkDate;
            string input;

            do
            {
                Console.WriteLine(mess);
                input = Console.ReadLine();
            }
            while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out checkDate));

            return checkDate;
        }
        
        
        
        public MonthLevel AddNote(MonthLevel addnote, string add, int day)
        {
            MonthLevel newCalentdar = addnote;
            var noteCell = newCalentdar.Month.FindAll(x => x.Symbol == day.ToString());
            /*var textNote = noteCell[0].Note;
            var date = new Day(newCalentdar)*/
            noteCell[0].Note = add;
            noteCell[0].Color = ConsoleColor.Green;



            return newCalentdar;
        }






    }
}
