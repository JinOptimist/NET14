using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class SleepingBag : BaseCell
    {
        public override char Symbol => 'D';

        public SleepingBag(IMazeLevel mazeLevel) : base(mazeLevel)
        {
        }

        public override bool TryToStep(IСharacter hero)
        {
            hero.Stamina = hero.Stamina + 10;
            hero.Mood = Mood.Bad;

            _mazeLevel.ReplaceCell(new Ground(_mazeLevel)
            {
                X = X,
                Y = Y
            });

            return true;
        }

    }
}
