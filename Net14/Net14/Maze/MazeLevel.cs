using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze
{
    public class MazeLevel
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public List<Cell> Cells { get; set; }
    }
}
