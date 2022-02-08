using Net14.Maze.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Net14.Maze
{
    public class MazeBuilder
    {
        private MazeLevel mazeLevel;

        public MazeLevel Build(int width = 5, int hegith = 7)
        {
            mazeLevel = GetBaseMaze(width, hegith);

            //Весь лабиринт только в стенах
            BuildWall();

            //Ломаем стены где положенно
            BuildGround();


            AddDoors();

            // Добавляем точку входа Х
            EnterPoint();

            // добавляем точку выхода @
            ExitPoint();

            AddHero();

            return mazeLevel;
        }

        private void AddHero()
        {
            var enter = mazeLevel.Cells.OfType<Enter>().Single();
            mazeLevel.Hero = new Сharacter()
            {
                X = enter.X,
                Y = enter.Y
            };
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
            mazeLevel.ReplaceCell(new Ground
            {
                X = redMinerCell.X,
                Y = redMinerCell.Y
            });


            //Список стен которые можно сломать. Пока он пустой и это нормально
            var blueWallCanBVreak = new List<BaseCell>();

            do
            {
                //Если хотим смотрим по шагово, как он ломает стены
                //drawer.DrawMaze(mazeLevel);
                //Thread.Sleep(200);
                
                //Берём ближайшие стены к шахтёру
                var nearWalls = GetNearCells<Wall>(
                    mazeLevel.Cells,
                    redMinerCell);

                //Добавляем к стенам который можно ломать,
                //стены которые рядом с шахтёром
                blueWallCanBVreak.AddRange(nearWalls);
                

                //Перепроверяем, все стены которые можно ломать,
                //нет ли среди них стены, рядом с которыми две ячейки земли
                //Такие стены ломать нельзя, вычёркиваем их из списка
                blueWallCanBVreak = blueWallCanBVreak
                   .Where(cell =>
                       GetNearCells<Ground>(mazeLevel.Cells, cell).Count < 2
                   ).ToList();

                //Берём из доступных стен для ломания, одну случайную
                var wallToBreak = GetRandom(blueWallCanBVreak);
                //Ломаем ей
                mazeLevel.ReplaceCell(new Ground()
                {
                    X = wallToBreak.X,
                    Y = wallToBreak.Y
                });
                //Удаляем из списка доступных для ломания, текущую стену
                blueWallCanBVreak.Remove(wallToBreak);

                //Переставляем шахтёра на текущую стену
                redMinerCell = wallToBreak;

                //Ещё разок перепроверяем все синие стены доступные для
                //ломания. Точно ли их можно ломать
                blueWallCanBVreak = blueWallCanBVreak
                    .Where(cell =>
                        GetNearCells<Ground>(mazeLevel.Cells, cell).Count < 2
                    ).ToList();

                //До тех пор пока есть стены которые можно ломать, продолжаем
                
            } while (blueWallCanBVreak.Any());
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
                    var cell = new Wall
                    {
                        X = x,
                        Y = y,
                        Color = ConsoleColor.Green,
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
                    var cell = new Ground
                    {
                        X = x,
                        Y = y,
                        Color = ConsoleColor.Red
                    };

                    mazeLevel.Cells.Add(cell);
                }
            }

            mazeLevel.ReplaceCell(new Wall()
            {
                X = 1,
                Y = 0
            });

            mazeLevel.ReplaceCell(new Wall()
            {
                X = 1,
                Y = 2
            });

            return mazeLevel;
        }

        public MazeLevel BuildChessMaze(int width = 32, int height = 32)
        {
            var mazeLevel = GetBaseMaze(width, height);
            //int i = 0;
            for (int y = 0; y < mazeLevel.Height; y++)
            {
                for (int x = 0; x < mazeLevel.Width; x++)
                {
                    var colorNumber = x % 16;
                    var cell = new Wall
                    {
                        X = x,
                        Y = y,
                        Color = (ConsoleColor)colorNumber,
                        BackColor = ConsoleColor.Black
                    };

                    if ((x + y) % 2 == 1)
                    {
                        cell.Color = (ConsoleColor)colorNumber;
                        cell.BackColor = ConsoleColor.Black;
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
            mazeLevel.Cells = new List<BaseCell>();
            return mazeLevel;
        }

        /// <summary>
        /// Возвращаем случайную ячейку из переднного списка
        /// </summary>
        /// <param name="cells"></param>
        /// <returns></returns>
        private BaseCell GetRandom(IEnumerable<BaseCell> cells)
        {
            var list = cells.ToList();
            var random = new Random();
            var randomIndex = random.Next(0, list.Count);
            return list[randomIndex];
        }

        /// <summary>
        /// Ищем ближайшие ячейки к переданной
        /// </summary>
        /// <param name="allCells">Все стены</param>
        /// <param name="currentCell">Текущая ячейка</param>
        /// <param name="cellSymbol">Искомые типы ячеек например Wall</param>
        /// <returns></returns>
        private List<CellType> GetNearCells<CellType>(
            List<BaseCell> allCells,
            BaseCell currentCell)
        {
            var nearCells = allCells
                .Where(cell =>
                    cell.X == currentCell.X
                    && Math.Abs(cell.Y - currentCell.Y) == 1//Abs это модуль
                    ||
                    cell.Y == currentCell.Y
                    && Math.Abs(cell.X - currentCell.X) == 1);
            return nearCells
                .OfType<CellType>()
                .ToList();
        }


        private List<Cell> Get2YWalls(List<Cell> allCells, Cell currentCell, char cellSymbol)
        {
            var YWalls = allCells
                .Where(cell => cell.X == currentCell.X && Math.Abs(cell.Y - currentCell.Y) == 1)
                .Where(cell => cell.Symbol == Wall);
            return YWalls.ToList();
        }
        private List<Cell> Get2XWalls(List<Cell> allCells, Cell currentCell, char cellSymbol)
        {
            var YWalls = allCells
                .Where(cell => cell.Y == currentCell.Y && Math.Abs(cell.X - currentCell.X) == 1)
                .Where(cell => cell.Symbol == Wall);
            return YWalls.ToList();
        }
        private void AddDoors()
        {
            
                var XDoorsCells = mazeLevel.Cells
                    .Where(cell => cell.Symbol == Ground)
                    .Where(cell => Get2YWalls(mazeLevel.Cells, cell, Wall).Count == 2)
                    .ToList();
                do
                {
                var DoorsX = GetRandom(XDoorsCells);
                DoorsX.Symbol = DoorX;
                XDoorsCells.Remove(DoorsX);
                } while (XDoorsCells.Any());
                
                var YDoorsCells = mazeLevel.Cells
                    .Where(cell => cell.Symbol == Ground)
                    .Where(cell => Get2XWalls(mazeLevel.Cells, cell, Wall).Count == 2)
                    .ToList();
                do
                {
                var DoorsY = GetRandom(YDoorsCells);
                DoorsY.Symbol = DoorY;
                YDoorsCells.Remove(DoorsY);
                } while (YDoorsCells.Any());
                

        private void ExitPoint()
        {
            // Выбираем крайние ячейки земли
            var extremCell = mazeLevel.Cells
                .OfType<Ground>()
                .Where(cell =>
                    cell.X == 0 || cell.Y == 0
                    || cell.X == mazeLevel.Width - 1
                    || cell.Y == mazeLevel.Height - 1)
                    .ToList();

            // Ищем крайние ячейки радом с которыми есть 1 земля
            extremCell = extremCell
                   .Where(cell =>
                       GetNearCells<Ground>(mazeLevel.Cells, cell).Count == 1
                   ).ToList();
            // Ищем крайние ячейки радом с которыми есть 1 стена (угловые)
            extremCell = extremCell
                   .Where(cell =>
                       GetNearCells<Wall>(mazeLevel.Cells, cell).Count == 1
                   ).ToList();
            // Выбираем из них выход
            var exit = GetRandom(extremCell);

            mazeLevel.ReplaceCell(new Exit()
            {
                X = exit.X,
                Y = exit.Y
            });
            exit.Color = ConsoleColor.Red;

        }
        private void EnterPoint()
        {
            // Выбираем не крайние ячейки
            var interiorCell = mazeLevel.Cells
                .OfType<Ground>()
                .Where(cell =>
                    cell.X != 0
                    && cell.Y != 0
                    && cell.Y != mazeLevel.Height - 1)
                .ToList();

            interiorCell = interiorCell
                   .Where(cell =>
                       GetNearCells<Ground>(mazeLevel.Cells, cell).Count >= 3
                   ).ToList();


            var enter = GetRandom(interiorCell);
            mazeLevel.ReplaceCell(new Enter()
            {
                X = enter.X,
                Y = enter.Y
            });
            enter.Color = ConsoleColor.Cyan;
        }

        private int AskForSize(string message)
        {
            Console.WriteLine(message);
            int parameter = Int32.Parse(Console.ReadLine());
            return parameter;

        }
    }
}
