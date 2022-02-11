using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class Clover : BaseCell
    {
        public int CloverCount { get; set; }
        public override char Symbol => '*';

        public Clover(MazeLevel mazeLevel) : base(mazeLevel)
        {
        }

        public override bool TryToStep(IСharacter hero)
        {
            var mood = (int)hero.Mood;
            if (mood < 5)
            {
                hero.Mood++;
            }

            hero.Coins += CloverCount;

            _mazeLevel.ReplaceCell(new Ground(_mazeLevel)
            {
                X = X,
                Y = Y
            });

            return true;
        }
    }
}
