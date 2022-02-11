using Net14.Maze.Cells;
using System.Collections.Generic;

namespace Net14.Maze
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