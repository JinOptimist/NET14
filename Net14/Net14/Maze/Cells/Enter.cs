﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class Enter : BaseCell
    {
        public override char Symbol => 'x';

        public Enter(IMazeLevel mazeLevel) : base(mazeLevel)
        {

        }
        public override bool TryToStep(IСharacter hero)
        {
            return true;
        }
    }
}
