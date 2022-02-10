using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class RandomTeleport : BaseCell
    {
        public override char Symbol => 'R';
        public override bool TryToStep(Сharacter hero)
        {
            hero.MessageInMyHead = "Teleportation in random plase";
            return true;
        }

    }
}
