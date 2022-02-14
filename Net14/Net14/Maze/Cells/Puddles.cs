using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class Puddles : BaseCell
    {
        public override char Symbol => '.';
        public override ConsoleColor BackColor => ConsoleColor.DarkBlue;
        public Puddles(IMazeLevel mazeLevel) : base(mazeLevel) 
        {

        }
        public override bool TryToStep(IСharacter hero)
        {
            hero.Stamina--;
            return true;
        }
    }
}
