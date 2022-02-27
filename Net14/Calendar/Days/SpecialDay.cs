using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Days
{
    
    public class SpecialDay
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Note { get; set; }
        
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;

        
    }
}
