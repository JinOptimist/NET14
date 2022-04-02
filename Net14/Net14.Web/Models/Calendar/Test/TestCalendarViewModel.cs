using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.Calendar.Test
{
    public class TestCalendarViewModel
    {
        public virtual List<NotesViewModel> Notes { get; set; }
        public List<int> Days { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        

    }
}
