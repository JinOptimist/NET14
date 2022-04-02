using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.Calendar
{
    public class CalendarViewModel
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string DOW { get; set; }
        public bool IsHoliday { get; set; }
        public ConsoleColor Color { get; set; }
        public virtual List<NotesViewModel> Notes { get; set; }
        public int month { get; set; }
        public int page { get; set; }
    }
}
