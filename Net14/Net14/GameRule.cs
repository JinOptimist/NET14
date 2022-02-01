using System;
using System.Collections.Generic;
using System.Text;

namespace Net14
{
    /// <summary>
    /// Cool class for store game rule
    /// </summary>
    class GameRule
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Number { get; set; }
        public int AttemptCountBeforeLoose { get; set; }
    }
}
