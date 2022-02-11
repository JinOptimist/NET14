using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    internal class SleepingBag : BaseCell
    {
        public override char Symbol => 'D';

        public override bool TryToStep(IСharacter hero)
        {
            return true;
        }

    }
}
