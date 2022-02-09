using Net14.Maze;
using Net14.Maze.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net14
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new MazeBuilder();
            var drawer = new Drawer();

            //Создали лабиринт
            var maze = builder.Build(12, 7);

            var wanaPlay = true;
            while (wanaPlay)
            {
                //Нарисовали лабиринт
                drawer.DrawMaze(maze);
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        maze.Move(Direction.Left);
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        maze.Move(Direction.Down);
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        maze.Move(Direction.Right);
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        maze.Move(Direction.Up);
                        break;
                    case ConsoleKey.Escape:
                        wanaPlay = false;
                        break;
                }
            }
            
        }
    }
}
