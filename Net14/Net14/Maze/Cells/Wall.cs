using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class Wall : BaseCell
    {
        public override char Symbol => '#';

        public Wall(MazeLevel mazeLevel) : base(mazeLevel)
        {
        }

        public override bool TryToStep(IСharacter hero)
        {
            hero.MessageInMyHead = "Boom";
            return false;
        }
    }
}
