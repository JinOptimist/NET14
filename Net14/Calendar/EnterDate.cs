using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Calendar
{
    public class EnterDate
    {
        public List<DateTime> SpecialList { get; set; }
        
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
        
        public List<string> Note(string mess)
        {
            DateTime seeNote = Date(mess);
            MonthLevel newCalentdar = new CreateCalendar().Create(seeNote.Year, seeNote.Month, 7, 4);
            var noteCell = newCalentdar.Month.FindAll(x => x.Symbol == seeNote.Day.ToString());
            var textNote = noteCell[0].Note;
            List<string> fullDay = new List<string> { seeNote.ToString("dd/MM/yyyy"), textNote};

            
            return fullDay;
        }
        public string AddNote(string add, DateTime date)
        {
            var day = add;
            var specialDay = date;

            return "В процессе разработки\n\n";
        }






    }
}
