using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class OpenDoors: BaseCell

    {
        public OpenDoors(IMazeLevel mazeLevel) : base(mazeLevel)
        {
        }

        public override char Symbol => '/';
        public override bool TryToStep(IСharacter hero)
        {
            return true;
        }
    }
}
