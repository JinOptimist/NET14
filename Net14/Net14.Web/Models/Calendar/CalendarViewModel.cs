using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.Calendar
{
    public class CalendarViewModel
    {
        public int DayNumber { get; set; } = 1;
        public int MonthNumber { get; set; } = DateTime.Now.Month;
        public int Year { get; set; } = DateTime.Now.Year;
        public string EmptyDays { get; set; } = " ";
        public List<string> Month { get; set; }
    }
}

