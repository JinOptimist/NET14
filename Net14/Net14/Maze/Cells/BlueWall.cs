using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    class BlueWall : BaseCell
    {
        public override char Symbol => '#';
        public override ConsoleColor Color => ConsoleColor.DarkBlue;

        public override bool TryToStep(Сharacter hero)
        {
            hero.MessageInMyHead = "Boom";
            return false;
        }
    }
}
