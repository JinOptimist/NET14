using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.DbModel
{
    public class Days : BaseModel
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string DayOfWeek { get; set; } 
        public bool IsHoliday { get; set; }

        public virtual List<DaysNote> Notes { get; set; }
    }
}
