using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using Microsoft.VisualBasic;

namespace Calendar
{
    public class CreateCalendar
    {
        
        public void Actual()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("Now is:");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Mounth is:");
            Console.WriteLine(now.Month);


        }
    }
}
