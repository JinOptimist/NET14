using System;
using System.Collections.Generic;
using System.Text;

namespace MazeCool.Cells
{
    public class ChestCoin : BaseCell
    {
        public int CoinsCount { get; set; }
        public override char Symbol => '@';
        public override ConsoleColor Color => ConsoleColor.Yellow;

        public ChestCoin(IMazeLevel mazeLevel) : base(mazeLevel)
        {
        }

        public override bool TryToStep(IСharacter hero)
        {
            hero.Coins += CoinsCount;
            _mazeLevel.ReplaceCell(new Ground(_mazeLevel)
            {
                X = X,
                Y = Y
            });
            return true;
        }
    }
}
