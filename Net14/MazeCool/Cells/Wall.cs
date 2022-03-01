using System;
using System.Collections.Generic;
using System.Text;

namespace MazeCool.Cells
{
    public class Wall : BaseCell
    {
        public override char Symbol => '#';

        public Wall(IMazeLevel mazeLevel) : base(mazeLevel)
        {
        }

        public override bool TryToStep(IСharacter hero)
        {
            hero.MessageInMyHead = "Boom";
            return false;
        }
    }
}
