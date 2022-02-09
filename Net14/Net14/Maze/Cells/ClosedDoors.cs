using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class ClosedDoors :BaseCell
    {
        public override char Symbol => '|';
        public override bool TryToStep(Сharacter hero)
        {
            hero.MessageInMyHead = "Opening end Enter";
            return true;
            }
    }
}
