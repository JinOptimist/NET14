﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class Exit : BaseCell
    {
        public override char Symbol => 'e';

        public Exit(IMazeLevel mazeLevel) : base(mazeLevel)
        {

        }

        public override bool TryToStep(IСharacter hero)
        {
            return true;
        }
    }
}
