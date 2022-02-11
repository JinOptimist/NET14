using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    class Puddles : BaseCell
    {
        public override char Symbol => '.';
        public override ConsoleColor BackColor => ConsoleColor.DarkBlue;

        public override bool TryToStep(Сharacter hero)
        {
            hero.Stamina--;
            return true;
        }
    }
}
