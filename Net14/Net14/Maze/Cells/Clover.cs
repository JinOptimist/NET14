using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class Clover : BaseCell
    {
        public int CloverCount { get; set; }
        public override char Symbol => '*';

        public override bool TryToStep(Сharacter hero)
        {
            hero.Coins += CloverCount;
            return true;
        }
    }
}
