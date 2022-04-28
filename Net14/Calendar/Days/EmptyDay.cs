using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Days
{
    public class EmptyDay : BaseDays
    {
        public EmptyDay(IMonthLevel monthLevel) : base(monthLevel)
        {
        }

        public override int Year => throw new NotImplementedException();

        public override int Month => throw new NotImplementedException();

        public override int Date => throw new NotImplementedException();

        public override string Note { get; set; }
    }
    
}
