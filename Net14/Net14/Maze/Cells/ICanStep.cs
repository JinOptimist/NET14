using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public interface ICanStep
    {
        bool TryToStep(IСharacter hero);
    }
}
