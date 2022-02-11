using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class ChestCoin : BaseCell
    {
        public int CoinsCount { get; set; }
        public override char Symbol => '@';
        public override bool TryToStep(IСharacter hero)
        {
            hero.Coins += CoinsCount;
            return true;
        }
    }
}
