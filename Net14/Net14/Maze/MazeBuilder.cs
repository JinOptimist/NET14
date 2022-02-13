using Net14.Maze.Cells;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Net14.Maze
{
    public class MazeBuilder
    {
        private MazeLevel mazeLevel;
        private readonly Random _random = new();

        public MazeLevel Build(int width = 5, int hegith = 7)
        {
            mazeLevel = GetBaseMaze(width, hegith);

            //Весь лабиринт только в стенах
            BuildWall();

            //Ломаем стены где положенно
            BuildGround();


            //AddDoors();
            BuildRandomBlueWall();

            BuildRedColorWall();

            BuildBlueGroundNearBlueWalls();

            // Добавляем точку входа Х
            EnterPoint();

            // добавляем точку выхода e
            ExitPoint();

            AddCoins();

            GreateSleepingBag();

            AddClover();

            AddTraps();

            AddChestOfLuck();

            return mazeLevel;
        }

        
        private void AddHero()
        {
            var enter = mazeLevel.Cells.OfType<Enter>().Single();
            mazeLevel.Hero = new Сharacter(mazeLevel)
            {
                X = enter.X,
                Y = enter.Y,
                Hp = 2,
                Stamina = 10,
                Mood = Mood.Normal
            };


        }

        private void BuildRandomBlueWall()
        {
            Random POfBlueWall = new Random();
            var per = 0.1;



            foreach (BaseCell cell in mazeLevel.Cells.OfType<Wall>().ToList())
            {
                if (POfBlueWall.NextDouble() <= per)
                {
                    cell.Color = ConsoleColor.DarkBlue;

                }
            }


        }
        private void BuildBlueGroundNearBlueWalls()
        {

            foreach (BaseCell BlueWall in mazeLevel.Cells.OfType<Wall>().ToList().Where(cell => cell.Color == ConsoleColor.DarkBlue))
            {
                var GroundNearBlueWalls = mazeLevel.Cells
                    .Where(cell =>
                    (cell.X == BlueWall.X
                    && Math.Abs(cell.Y - BlueWall.Y) == 1)
                    ||
                    (cell.Y == BlueWall.Y
                    && Math.Abs(cell.X - BlueWall.X) == 1)).ToList().OfType<Ground>().ToList();

                foreach (BaseCell CellWithGroundNearBlueWalls in GroundNearBlueWalls)
                {
                    var Hello = mazeLevel.Cells
                    .Where(cells =>
                    (cells.X == CellWithGroundNearBlueWalls.X
                    && Math.Abs(cells.Y - CellWithGroundNearBlueWalls.Y) == 1)
                    ||
                    (cells.Y == CellWithGroundNearBlueWalls.Y
                    && Math.Abs(cells.X - CellWithGroundNearBlueWalls.X) == 1)).ToList()
                    .OfType<Wall>()
                    .Where(cell => cell.Color == ConsoleColor.Red).ToList();
                    /*.Where(cells =>
                    (cells.Symbol == Wall
                    && cells.Color == ConsoleColor.Red)).ToList();*/
                    /*         && (cells.X == BlueWall.X && cells.Y != BlueWall.Y
                             || cells.Y == BlueWall.Y && cells.X != BlueWall.X)).ToList();*/
                    if (Hello.Count == 0)
                    {
                        CellWithGroundNearBlueWalls.BackColor = ConsoleColor.DarkBlue;
                    }


                }

            }

        }
        private void BuildRedColorWall()
        {
            Random POfBlueWall = new Random();
            var per = 5;

            foreach (BaseCell cell in mazeLevel.Cells.OfType<Wall>().Where(cell => cell.Color != ConsoleColor.DarkBlue))
            {
                if (POfBlueWall.Next(0, 100) <= per)
                {
                    cell.Color = ConsoleColor.Red;
                }
            }
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
            mazeLevel.ReplaceCell(new Ground(mazeLevel)
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
                mazeLevel.ReplaceCell(new Ground(mazeLevel)
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
                    var cell = new Wall(mazeLevel)
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
                    var cell = new Ground(mazeLevel)
                    {
                        X = x,
                        Y = y,
                        Color = ConsoleColor.Red
                    };

                    mazeLevel.Cells.Add(cell);
                }
            }

            mazeLevel.ReplaceCell(new Wall(mazeLevel)
            {
                X = 1,
                Y = 0
            });

            mazeLevel.ReplaceCell(new Wall(mazeLevel)
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
                    var cell = new Wall(mazeLevel)
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
            var randomIndex = random.Next(0, list.Count - 1);
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
            BaseCell currentCell) where CellType : BaseCell
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

        private List<Wall> Get2YWallsAroundGround<Wall>(List<BaseCell> allCells, BaseCell currentCell)
        {
            var YWallsAroundGround = allCells
                .Where(cell => cell.X == currentCell.X && Math.Abs(cell.Y - currentCell.Y) == 1);
            return YWallsAroundGround.OfType<Wall>().ToList();
        }
        private List<Wall> Get2XWallsAroundGround<Wall>(List<BaseCell> allCells, BaseCell currentCell)
        {
            var XWallsAroundGround = allCells
                .Where(cell => cell.Y == currentCell.Y && Math.Abs(cell.X - currentCell.X) == 1);
            return XWallsAroundGround.OfType<Wall>().ToList();
        }
        private void AddDoors()
        {
            var XDoorsCells = mazeLevel.Cells
                .Where(cell => Get2XWallsAroundGround<Wall>(mazeLevel.Cells, cell).Count == 2)
                .ToList();
            var YDoorsCells = mazeLevel.Cells
                .Where(cell => Get2YWallsAroundGround<Wall>(mazeLevel.Cells, cell).Count == 2)
                .ToList();
                
                Random RandomDoorX = new Random();
                foreach (var i in XDoorsCells)
                {
                var XDoorsSpawner = GetRandom(XDoorsCells);
                int RandomX = RandomDoorX.Next(0, 100);
                    if (RandomX < 30)
                    {
                        mazeLevel.ReplaceCell(new ClosedDoors()
                        {
                            X = XDoorsSpawner.X,
                            Y = XDoorsSpawner.Y
                        });
                    }
                }
                Random RandomDoorY = new Random();
                foreach (var j in XDoorsCells)
                {
                var YDoorsSpawner = GetRandom(YDoorsCells);
                int RandomY = RandomDoorY.Next(0, 100);
                    if (RandomY < 30)
                    {
                    mazeLevel.ReplaceCell(new ClosedDoors()
                    {
                        X = YDoorsSpawner.X,
                        Y = YDoorsSpawner.Y
                    });
                    }
                }
        }

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

            mazeLevel.ReplaceCell(new Exit(mazeLevel)
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
            mazeLevel.ReplaceCell(new Enter(mazeLevel)
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

        private void AddCoins()
        {
            var allDeadEnds = mazeLevel.Cells
                .OfType<Ground>()
                .Where(cell =>
                    GetNearCells<Ground>(mazeLevel.Cells, cell).Count() == 1)
                .ToList();

            foreach (var allDeadEnd in allDeadEnds)
            {
                var rnd = _random.Next(0, 100);
                var coinsCount = _random.Next(1, 10);

                if (rnd < 30)
                {
                    mazeLevel.ReplaceCell(new ChestCoin(mazeLevel)
                    {
                        X = allDeadEnd.X,
                        Y = allDeadEnd.Y,
                        CoinsCount = coinsCount
                    });
                }
            }
        }

        // Метод для создание спального места 
        public void GreateSleepingBag()
        {
            // Выбираем оставшиеся после методов выше ячейки земли
            var SleepCell = mazeLevel.Cells
                .OfType<Ground>()
                .Where(cell => GetNearCells<Ground>(mazeLevel.Cells, cell).Count == 1).ToList();

            // Рандомно ставим Спальник
            var sleepingBag = GetRandom(SleepCell);


            // Меняем символ земли на символ спальника
            mazeLevel.ReplaceCell(new SleepingBag(mazeLevel)
            {
                X = sleepingBag.X,
                Y = sleepingBag.Y,
                Color = ConsoleColor.Magenta
            });

        }

        public void AddClover()
        {
            var allGrounds = mazeLevel.Cells.OfType<Ground>().ToList();

            Random random = new Random();

            foreach (var allGround in allGrounds)
            {
                int rndm = random.Next(0, 100);

                if (rndm < 5)
                {
                    mazeLevel.ReplaceCell(new Clover(mazeLevel)
                    {
                        X = allGround.X,
                        Y = allGround.Y

                    });
                }
            }
        }
        public void AddTraps()
        {
            var allGroundNearCoins = mazeLevel.Cells
                .OfType<Ground>()
                .Where(cell =>
                    GetNearCells<ChestCoin>(mazeLevel.Cells, cell).Count() == 1)
                .ToList();

            Random random = new Random();

            foreach (var SuitableGround in allGroundNearCoins)
            {
                int FiftyFifty = random.Next(0, 2);

                if (FiftyFifty == 0)
                {
                    mazeLevel.ReplaceCell(new Trap(mazeLevel)
                    {
                        X = SuitableGround.X,
                        Y = SuitableGround.Y

                    });
                }
            }
        }



        public void AddChestOfLuck()
        {
            var allGrounds = mazeLevel.Cells.OfType<Ground>().ToList();

            Random random = new Random();

            foreach (var ground in allGrounds)
            {
                int rndm = random.Next(0, 100);

                if (rndm < 3)
                {
                    mazeLevel.ReplaceCell(new ChestOfLuck(mazeLevel)
                    {
                        X = ground.X,
                        Y = ground.Y

                    });
                }
            }
        }
    }
}
