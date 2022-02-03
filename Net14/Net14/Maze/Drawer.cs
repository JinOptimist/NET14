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
            var oldColor = Console.ForegroundColor;
            var oldColor2 = Console.BackgroundColor;

            for (int yIndex = 0; yIndex < mazeLevel.Height; yIndex++)
            {
                for (int xIndex = 0; xIndex < mazeLevel.Width; xIndex++)
                {

                    var cell = mazeLevel.Cells
                        .First(cell => cell.X == xIndex && cell.Y == yIndex);

                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = cell.Color;
                    Console.Write(cell.Symbol);
                    Console.ForegroundColor = oldColor;
                }

                Console.WriteLine();
            }
            Console.BackgroundColor = oldColor2;
            Console.ForegroundColor = oldColor;

        }
    }
}
