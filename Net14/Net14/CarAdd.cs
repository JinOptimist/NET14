using System;
using System.Collections.Generic;
using System.Text;

namespace Net14
{
    class CarAdd
    {
        private string Name { get; set; }
        private int Power { get; set; }
        private int MaxSpeed { get; set; }

        public void Show()
        {
            Console.WriteLine(Name, Power, MaxSpeed);
        }
    }
}
