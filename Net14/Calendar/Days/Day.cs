using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Days
{
    public class Day : BaseDays
    {
        public Day(IMonthLevel monthLevel) : base(monthLevel)
        {

        }

        public override int Year => DateTime.Now.Year;
        public override int Month => DateTime.Now.Month;
        public override int Date => DateTime.Now.Day;
        
    }
}
