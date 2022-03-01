using MazeCool.Cells;
using System.Collections.Generic;

namespace MazeCool
{
    public interface IMazeLevel
    {
        List<BaseCell> Cells { get; set; }
        int Height { get; set; }
        Сharacter Hero { get; set; }
        int Width { get; set; }

        void Move(Direction left);
        void ReplaceCell(BaseCell cell);
    }
}