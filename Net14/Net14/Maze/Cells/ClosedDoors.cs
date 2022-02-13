using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class ClosedDoors : BaseCell
    {
        public ClosedDoors(IMazeLevel mazeLevel) : base(mazeLevel)
        {
        }

        public override char Symbol => '|';

        public override bool TryToStep(IСharacter hero)
        {
            hero.MessageInMyHead = "Opening";
            _mazeLevel.ReplaceCell(new OpenDoors(_mazeLevel)
            {
                X = this.X,
                Y = this.Y
            });
            return false;
        }
    }
}
