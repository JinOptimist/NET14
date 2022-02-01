using System;
using System.Collections.Generic;
using System.Text;

namespace Net14
{
    class Movie
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; } 
        public string[] Actors { get; set; }
        public bool HasOscar { get; set; } 
    }
}
