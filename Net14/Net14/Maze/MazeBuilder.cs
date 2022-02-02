using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net14.Maze
{
    public class MazeBuilder
    {
        public MazeLevel Build(int width = 5, int hegith = 7)
        {
            var mazeLevel = GetBaseMaze(width, hegith);

            for (int y = 0; y < mazeLevel.Height; y++)
            {
                for (int x = 0; x < mazeLevel.Width; x++)
                {
                    var cell = new Cell
                    {
                        X = x,
                        Y = y,
                        Color = ConsoleColor.Green,
                        Symbol = '#'
                    };

                    if ((x + y) % 3 == 1)
                    {
                        cell.Symbol = '@';
                        cell.Color = ConsoleColor.Blue;
                    }

                    mazeLevel.Cells.Add(cell);
                }
            }

            return mazeLevel;
        }

        public MazeLevel BuildSmallStandrad()
        {
            var mazeLevel = GetBaseMaze(3, 3);

            for (int y = 0; y < mazeLevel.Height; y++)
            {
                for (int x = 0; x < mazeLevel.Width; x++)
                {
                    var cell = new Cell
                    {
                        X = x,
                        Y = y,
                        Symbol = '_',
                        Color = ConsoleColor.Red
                    };

                    mazeLevel.Cells.Add(cell);
                }
            }

            var firstCell = mazeLevel.Cells
                .First(cell => cell.X == 1 && cell.Y == 0);
            firstCell.Symbol = '#';

            var secondCell = mazeLevel.Cells
                .First(cell => cell.X == 1 && cell.Y == 2);
            secondCell.Symbol = '#';

            return mazeLevel;
        }

        public MazeLevel GetMazeWithRandomLetters(int width, int height) 
        {
            Random generateRandomLetters = new Random();
            var maze = GetBaseMaze(width, height);
            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    int num = generateRandomLetters.Next(0, 26);
                    char letter = (char)('a' + num);
                    var cell = new Cell
                    {
                        X = x,
                        Y = y,
                        Symbol = letter,
                        Color = ConsoleColor.Red
                    };

                    maze.Cells.Add(cell);
                }
            }
            return maze;


        }

        private MazeLevel GetBaseMaze(int width, int height)
        {
            var mazeLevel = new MazeLevel();
            mazeLevel.Width = width;
            mazeLevel.Height = height;
            mazeLevel.Cells = new List<Cell>();
            return mazeLevel;
        }
    }
}
