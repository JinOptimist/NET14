using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class ChestCoin : BaseCell
    {
        public int CoinsCount { get; set; }
        public override char Symbol => '@';
        public override ConsoleColor Color => ConsoleColor.Yellow;

        public ChestCoin(MazeLevel mazeLevel) : base(mazeLevel)
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
