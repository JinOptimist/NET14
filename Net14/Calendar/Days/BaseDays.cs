using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Days
{
    public abstract class BaseDays
    {
        public abstract int Year { get; }
        public abstract int Month { get; }
        public abstract int Date { get; }
        public string Symbol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public virtual ConsoleColor Color { get; set; } = ConsoleColor.White;
        public virtual ConsoleColor BackColor { get; set; } = ConsoleColor.Black;
        protected IMonthLevel _monthLevel;
        public BaseDays(IMonthLevel monthLevel)
        {
            _monthLevel = monthLevel;
        }

    }
}
