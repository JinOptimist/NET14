using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Net14.Maze
{
    public class MazeBuilder
    {
        public const char Wall = '#';
        public const char Ground = '_';

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
                        Symbol = Wall
                    };

                    mazeLevel.Cells.Add(cell);
                }
            }

            var drawer = new Drawer();

            var coreCell = mazeLevel
                .Cells
                .Where(cell => cell.X != 0
                    && cell.X != mazeLevel.Width - 1
                    && cell.Y != 0
                    && cell.Y != mazeLevel.Height - 1)
                .ToList();

            var redMinerCell = GetRandom(coreCell);

            redMinerCell.Symbol = Ground;

            var blueWallCanBVreak = new List<Cell>();

            do
            {
                //drawer.DrawMaze(mazeLevel);
                //Thread.Sleep(200);
                var nearWalls = GetNearCells(
                    mazeLevel.Cells,
                    redMinerCell,
                    Wall);

                blueWallCanBVreak.AddRange(nearWalls);
                //blueWallCanBVreak.ForEach(x => x.Color = ConsoleColor.Blue);

                blueWallCanBVreak = blueWallCanBVreak
                   .Where(cell =>
                       GetNearCells(mazeLevel.Cells, cell, Ground).Count < 2
                   ).ToList();

                var wallToBreak = GetRandom(blueWallCanBVreak);
                wallToBreak.Symbol = Ground;
                blueWallCanBVreak.Remove(wallToBreak);


                redMinerCell = wallToBreak;

                blueWallCanBVreak = blueWallCanBVreak
                    .Where(cell =>
                        GetNearCells(mazeLevel.Cells, cell, Ground).Count < 2
                    ).ToList();
            } while (blueWallCanBVreak.Any());

            foreach (Cell cell in mazeLevel.Cells.Where(cell => cell.Symbol == Wall)) 
            {
                RandomChageColorofWall(cell);
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

        public MazeLevel BuildChessMaze(int width = 32, int height = 32)
        {
            var mazeLevel = GetBaseMaze(width, height);

            for (int y = 0; y < mazeLevel.Height; y++)
            {
                for (int x = 0; x < mazeLevel.Width; x++)
                {
                    var cell = new Cell
                    {
                        X = x,
                        Y = y,
                        Color = ConsoleColor.White,
                        Symbol = '#',
                        BackColor = ConsoleColor.Black
                    };

                    if ((x + y) % 2 == 1)
                    {
                        cell.Symbol = '#';
                        cell.Color = ConsoleColor.White;
                        cell.BackColor = ConsoleColor.DarkRed;
                    }

                    mazeLevel.Cells.Add(cell);
                }
            }

            return mazeLevel;
        }

        private MazeLevel GetBaseMaze(int width, int height)
        {
            var mazeLevel = new MazeLevel();
            mazeLevel.Width = width;
            mazeLevel.Height = height;
            mazeLevel.Cells = new List<Cell>();
            return mazeLevel;
        }

        private Cell GetRandom(List<Cell> cells)
        {
            var random = new Random();
            var randomIndex = random.Next(0, cells.Count);
            return cells[randomIndex];
        }

        private List<Cell> GetNearCells(
            List<Cell> allCells,
            Cell currentCell,
            char cellSymbol)
        {
            var nearWalls = allCells
                .Where(cell =>
                    cell.X == currentCell.X
                    && Math.Abs(cell.Y - currentCell.Y) == 1
                    ||
                    cell.Y == currentCell.Y
                    && Math.Abs(cell.X - currentCell.X) == 1)
                .Where(cell => cell.Symbol == cellSymbol);

            return nearWalls.ToList();
        }

        private Cell RandomChageColorofWall(Cell cell) 
        {
            Random POfColor = new Random();
            var per = 0.1;
            if (POfColor.NextDouble() <+ per)
            {
                cell.Color = ConsoleColor.Blue;
            }

            return cell;
           
        }
    }
}
