using System;
using System.Collections.Generic;
using System.Text;

namespace MazeCool.Cells
{
    public interface ICanStep
    {
        bool TryToStep(IСharacter hero);
    }
}
