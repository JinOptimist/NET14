using System;
using System.Collections.Generic;
using System.Text;

namespace Net14
{
    class GameRule
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Number { get; set; }
        public int AttemptCountBeforeLoose { get; set; }
    }
}
