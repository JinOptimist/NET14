using System;
using System.Collections.Generic;
using System.Text;

namespace MazeCool.Cells
{
    public class Trap : BaseCell
    {
       public override char Symbol => 'T';

        public Trap(IMazeLevel mazeLevel) : base(mazeLevel)
        {
        }

        public override bool TryToStep(IСharacter hero)
        {
            hero.MessageInMyHead = "It's a Trap!!!";
            hero.Hp --;
            _mazeLevel.ReplaceCell(new Ground(_mazeLevel)
            {
                X = X,
                Y = Y
            });

            return true;
        }
    }
}
