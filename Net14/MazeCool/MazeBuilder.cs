using MazeCool.Cells;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeCool
{
    public class MazeBuilder
    {
        private MazeLevel mazeLevel;
        private readonly Random _random = new Random();

        public MazeLevel Build(int width = 5, int hegith = 7)
        {
            mazeLevel = GetBaseMaze(width, hegith);

            //Весь лабиринт только в стенах
            BuildWall();

            //Ломаем стены где положенно
            BuildGround();


            //AddDoors();


            // Добавляем точку входа Х
            EnterPoint();

            // добавляем точку выхода e
            ExitPoint();

            AddHero();

            AddCoins();
            RandomTeleportation();

            GreateSleepingBag();

            AddClover();

            AddTraps();

            AddChestOfLuck();

            AddDoors();

            BuildRandomBlueWall();

            BuildRedColorWall();

            BuildBluePuddles();

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
                    mazeLevel.ReplaceCell(new BlueWall(mazeLevel)
                    {
                        X = cell.X,
                        Y = cell.Y
                    });

                }
            }


        }
        private void BuildBluePuddles()
        {
            foreach (BaseCell BlueWall in mazeLevel.Cells.OfType<BlueWall>().ToList()) 
            {
                var GroundNearBlueWalls = GetNearCells<Ground>(mazeLevel.Cells, BlueWall);

                foreach (Ground groundNearBlueWall in GroundNearBlueWalls) 
                {
                    var IsRedWallNear = GetNearCells<RedWall>(mazeLevel.Cells, groundNearBlueWall).ToList();

                    if (IsRedWallNear.Count == 0) 
                    {
                        mazeLevel.ReplaceCell(new Puddles(mazeLevel)
                        {
                            X = groundNearBlueWall.X,
                            Y = groundNearBlueWall.Y
                        });
                    }
                }

            }

            
        }
        private void BuildRedColorWall()
        {
            Random POfBlueWall = new Random();
            var per = 5;

            foreach (BaseCell cell in mazeLevel.Cells.OfType<Wall>().Where(cell => cell.Color != ConsoleColor.DarkBlue).ToList())
            {
                if (POfBlueWall.Next(0, 100) <= per)
                {
                    mazeLevel.ReplaceCell(new RedWall(mazeLevel)
                    {
                        X = cell.X,
                        Y = cell.Y
                    });
                }
            }
        }

        private void BuildGround()
        {

            //Создаём рисовальщик, что бы по ходу создания
            //лабиринта, показывать промежуточные результаты
            //var drawer = new DrawerMaze();

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


      
        private List<BaseCell> GroundForSpawnDoors2Y(List<BaseCell> allCells, BaseCell currentCell)
        {
            var GroundForSpawn = allCells
                .Where(cell => cell.X == currentCell.X && Math.Abs(cell.Y - currentCell.Y) == 1 && cell is Wall);
                return GroundForSpawn.OfType<BaseCell>().ToList();
        }
        private List<BaseCell> GroundForSpawnDoors2X(List<BaseCell> allCells, BaseCell currentCell)
        {
            var GroundForSpawn = allCells
                .Where(cell => cell.Y == currentCell.Y && Math.Abs(cell.X - currentCell.X) == 1 && cell is Wall);
            return GroundForSpawn.OfType<BaseCell>().ToList();
        }
        private void AddDoors()
        {
            var GroundForDoors2Y = mazeLevel.Cells
                .Where(cell => cell is Ground)
                .Where(cell => GroundForSpawnDoors2Y(mazeLevel.Cells, cell).Count == 2)
                .ToList();
            do
            {
                var DoorSpawner = GetRandom(GroundForDoors2Y);
                mazeLevel.ReplaceCell(new ClosedDoors(mazeLevel)
                {
                    X = DoorSpawner.X,
                    Y = DoorSpawner.Y
                });
                GroundForDoors2Y.Remove(DoorSpawner);
            } while (GroundForDoors2Y.Any());

            var GroundForDoors2X = mazeLevel.Cells
                .Where(cell => cell is Ground)
                .Where(cell => GroundForSpawnDoors2X(mazeLevel.Cells, cell).Count == 2)
                .ToList();
            do
            {
                var DoorSpawner = GetRandom(GroundForDoors2X);
                mazeLevel.ReplaceCell(new ClosedDoors(mazeLevel)
                {
                    X = DoorSpawner.X,
                    Y = DoorSpawner.Y
                });
                GroundForDoors2X.Remove(DoorSpawner);
            } while (GroundForDoors2X.Any());

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

        private void RandomTeleportation()
        {
            var PlaceForTeleport = mazeLevel.Cells.OfType<Ground>().ToList();
            var SpawnTeleport = GetRandom(PlaceForTeleport);
            mazeLevel.ReplaceCell(new RandomTeleport(mazeLevel)
            {
                X = SpawnTeleport.X,
                Y = SpawnTeleport.Y
            });
        }
        
    }
}
