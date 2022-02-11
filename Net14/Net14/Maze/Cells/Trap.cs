﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class Trap : BaseCell
    {
        public int HealthCount { get; set; }
        public override char Symbol => 'T';

        public override bool TryToStep(IСharacter hero)
        {
            hero.MessageInMyHead = "It's a Trap!!!";
            hero.Hp -= HealthCount;
            return true;
        }
    }
}
