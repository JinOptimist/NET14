using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Days
{
    
    public abstract class SpecialDay
    {
        public abstract int Year { get; }
        public abstract int Month { get; }
        public abstract int Date { get; }
        public string Note { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public virtual ConsoleColor Color { get; set; } = ConsoleColor.Green;
    }
}
