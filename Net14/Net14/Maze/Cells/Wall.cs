using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class Wall : BaseCell
    {
        public override char Symbol => '#';
        public override bool TryToStep(Сharacter hero)
        {
            hero.MessageInMyHead = "Boom";
            return false;
        }
    }
}
