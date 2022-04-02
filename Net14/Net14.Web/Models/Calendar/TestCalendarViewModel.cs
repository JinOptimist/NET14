using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.Calendar
{
    public class TestCalendarViewModel
    {
        public int month { get; set; }
        public int year { get; set; }
        public virtual List<CalendarViewModel> Calendar { get; set; }
        public virtual List<NotesViewModel> Notes { get; set; }
        
    }
}
