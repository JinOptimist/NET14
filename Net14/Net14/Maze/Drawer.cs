using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net14.Maze
{
    public class Drawer
    {
   


        public void DrawMaze(MazeLevel mazeLevel)
        {
            Console.Clear();
            for (int yIndex = 0; yIndex < mazeLevel.Height; yIndex++)
            {
                for (int xIndex = 0; xIndex < mazeLevel.Width; xIndex++)
                {

                    var cell = mazeLevel.Cells
                        .First(cell => cell.X == xIndex && cell.Y == yIndex);

                    var oldColor = Console.ForegroundColor;
                    var oldBackColor = Console.BackgroundColor;
                    Console.ForegroundColor = cell.Color;
                    Console.BackgroundColor = cell.BackColor;
                    Console.Write(cell.Symbol);
                    Console.ForegroundColor = oldColor;
                    Console.BackgroundColor = oldBackColor;
                    
                }

                Console.WriteLine();
            }
        }
    }
}

