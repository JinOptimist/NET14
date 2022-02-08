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
            Weather();
            for (int yIndex = 0; yIndex < mazeLevel.Height; yIndex++)
            {
                for (int xIndex = 0; xIndex < mazeLevel.Width; xIndex++)
                {
                    var cell = mazeLevel.Cells
                        .First(cell => cell.X == xIndex && cell.Y == yIndex);

                    if (mazeLevel.Hero.X == xIndex
                        && mazeLevel.Hero.Y == yIndex)
                    {

                        DrawCell(mazeLevel.Hero);
                    }
                    else
                    {
                        DrawCell(cell);
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(mazeLevel.Hero.MessageInMyHead);
        }

        private void DrawCell(BaseCell cell)
        {
            var oldColor = Console.ForegroundColor;
            var oldBackColor = Console.BackgroundColor;

            Console.ForegroundColor = cell.Color;
            Console.BackgroundColor = cell.BackColor;
            Console.Write(cell.Symbol);
            Console.ForegroundColor = oldColor;
            Console.BackgroundColor = oldBackColor;
        }
        public void Weather()
        {
            string[] weather = new string[4] { "Foggy", "Snowy", "Rainy", "Sunny" };
            Console.WriteLine(weather[new Random().Next(0, weather.Length)]);
        }
    }
}

