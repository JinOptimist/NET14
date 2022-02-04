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
            Weather();
            for (int yIndex = 0; yIndex < mazeLevel.Height; yIndex++)
            {
                for (int xIndex = 0; xIndex < mazeLevel.Width; xIndex++)
                {

                    var cell = mazeLevel.Cells
                        .First(cell => cell.X == xIndex && cell.Y == yIndex);

                    var oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = cell.Color;
                    Console.Write(cell.Symbol);
                    Console.ForegroundColor = oldColor;
                }

                Console.WriteLine();
            }
        }
        public void Weather()
        {
            string[] weather = new string[4] { "Foggy", "Snowy", "Rainy", "Sunny" };
            Console.WriteLine(weather[new Random().Next(0, weather.Length)]);
        }
    }
}
