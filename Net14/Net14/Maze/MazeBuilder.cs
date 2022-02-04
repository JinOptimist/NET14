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

        private MazeLevel mazeLevel;

        public MazeLevel Build(int width = 5, int hegith = 7)
        {
            mazeLevel = GetBaseMaze(width, hegith);

            //Весь лабиринт только в стенах
            BuildWall();

            //Ломаем стены где положенно
            BuildGround();
            
            return mazeLevel;
        }

        private void BuildGround()
        {

            //Создаём рисовальщик, что бы по ходу создания
            //лабиринта, показывать промежуточные результаты
            var drawer = new Drawer();

            //Берём НЕ крайние значения
            var coreCell = mazeLevel // весь лабиринт
                .Cells //Все ячейки лабиринта
                .Where(cell =>  //Запускаем фильтрацию
                    cell.X != 0 // подходят ячейки у которых X не равен 0
                    && cell.X != mazeLevel.Width - 1 //и т.д.
                    && cell.Y != 0
                    && cell.Y != mazeLevel.Height - 1)
                .ToList();

            //Берём случайную ячейку из центральных и ставим туда Красного Шахтёра
            var redMinerCell = GetRandom(coreCell);

            //Ломаем стену. Точней у ячейки шахтёра
            //заменяем символ стены на символ земли
            redMinerCell.Symbol = Ground;

            //Список стен которые можно сломать. Пока он пустой и это нормально
            var blueWallCanBVreak = new List<Cell>();

            do
            {
                //Если хотим смотрим по шагово, как он ломает стены
                //drawer.DrawMaze(mazeLevel);
                //Thread.Sleep(200);

                //Берём ближайшие стены к шахтёру
                var nearWalls = GetNearCells(
                    mazeLevel.Cells,
                    redMinerCell,
                    Wall);

                //Добавляем к стенам который можно ломать,
                //стены которые рядом с шахтёром
                blueWallCanBVreak.AddRange(nearWalls);

                //Перепроверяем, все стены которые можно ломать,
                //нет ли среди них стены, рядом с которыми две ячейки земли
                //Такие стены ломат нельзя, вычёркиваем их из списка
                blueWallCanBVreak = blueWallCanBVreak
                   .Where(cell =>
                       GetNearCells(mazeLevel.Cells, cell, Ground).Count < 2
                   ).ToList();

                //Берём из доступных стен для ломание, одну случайную
                var wallToBreak = GetRandom(blueWallCanBVreak);
                //Ломаем ей
                wallToBreak.Symbol = Ground;
                //Удаляем из списка доступных для ломания, текущую стену
                blueWallCanBVreak.Remove(wallToBreak);

                //Переставляем шахтёра на текущую стену
                redMinerCell = wallToBreak;

                //Ещё разок перепроверяем все синие стены доступные для
                //ломания. Точно ли их можно ломать
                blueWallCanBVreak = blueWallCanBVreak
                    .Where(cell =>
                        GetNearCells(mazeLevel.Cells, cell, Ground).Count < 2
                    ).ToList();

                //До тех пор пока есть стены которые можно ломать, продолжаем
            } while (blueWallCanBVreak.Any());

            foreach (Cell cell in mazeLevel.Cells.Where(cell => cell.Symbol == Wall)) 
            {
                RandomChageColorofWall(cell);
            }

        /// <summary>
        /// Создаём лабиринт полный стен
        /// </summary>
        private void BuildWall()
        {
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

        /// <summary>
        /// Возвращаем случайную ячейку из переднного списка
        /// </summary>
        /// <param name="cells"></param>
        /// <returns></returns>
        private Cell GetRandom(List<Cell> cells)
        {
            var random = new Random();
            var randomIndex = random.Next(0, cells.Count);
            return cells[randomIndex];
        }

        /// <summary>
        /// Ищем ближайшие ячейки к переданной
        /// </summary>
        /// <param name="allCells">Все стены</param>
        /// <param name="currentCell">Текущая ячейка</param>
        /// <param name="cellSymbol">Искомые типы ячеек например Wall</param>
        /// <returns></returns>
        private List<Cell> GetNearCells(
            List<Cell> allCells,
            Cell currentCell,
            char cellSymbol)
        {
            var nearWalls = allCells
                .Where(cell =>
                    cell.X == currentCell.X
                    && Math.Abs(cell.Y - currentCell.Y) == 1//Abs это модуль
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
