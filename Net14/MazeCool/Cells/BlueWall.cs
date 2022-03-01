using System;
using System.Collections.Generic;
using System.Text;

namespace MazeCool.Cells
{
    class BlueWall : BaseCell
    {
        public override char Symbol => '#';
        public override ConsoleColor Color => ConsoleColor.DarkBlue;
        public BlueWall(IMazeLevel mazeLevel):base(mazeLevel)
        {

        }
        public override bool TryToStep(IСharacter hero)
        {
            hero.MessageInMyHead = "Boom";
            return false;
        }
    }
}
