using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    class RedWall : BaseCell
    {
        public override char Symbol => '#';
        public override ConsoleColor Color => ConsoleColor.Red;
        public RedWall(IMazeLevel mazeLevel) : base(mazeLevel) 
        {

        }
        public override bool TryToStep(IСharacter hero)
        {
            hero.Hp--;
            return false;
        }
    }
}
