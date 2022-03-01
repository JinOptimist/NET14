using System;
using System.Collections.Generic;
using System.Text;

namespace MazeCool.Cells
{
    public class Ground : BaseCell
    {
        public override char Symbol => '.';

        public Ground(IMazeLevel mazeLevel) : base(mazeLevel)
        {

        }

        public override bool TryToStep(IСharacter hero)
        {
            return true;
        }
    }
}
