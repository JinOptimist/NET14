using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    class RedWall : BaseCell
    {
        public override char Symbol => '#';
        public override ConsoleColor Color => ConsoleColor.Red;

        public override bool TryToStep(Сharacter hero)
        {
            hero.Hp--;
            return false;
        }
    }
}
