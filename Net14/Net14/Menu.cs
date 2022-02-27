using Calendar;
using Net14.Maze;
using System;
using System.Globalization;
using Calendar.Days;
using System.Collections.Generic;

namespace Net14
{
    class Menu
    {
        private const string HintMessage = "Enter your command, or enter 'help' to get help.";
        private const int CommandHelpIndex = 0;
        private const int DescriptionHelpIndex = 1;
        private const int ExplanationHelpIndex = 2;
        private static bool _isRunning = true;

        private readonly Tuple<string, Action<string>>[] _commands = new Tuple<string, Action<string>>[]
        {
            new Tuple<string, Action<string>>("help", PrintHelp),
            new Tuple<string, Action<string>>("exit", Exit),
            new Tuple<string, Action<string>>("Maze", PlayMaze),
            new Tuple<string, Action<string>>("Numbers", PlayThatNumber),
            new Tuple<string, Action<string>>("Description", ShowGameDescription),

            new Tuple<string, Action<string>>("Calendar", CreateCalendar),
            new Tuple<string, Action<string>>("ca", CreateCalendar),

        };

        private static readonly string[][] HelpMessages = new string[][]
        {
            new string[] { "help", "prints the help screen" },
            new string[] { "exit", "exits the application" },
            new string[] { "maze", "starts the game \"Maze\"" },
            new string[] { "numbers", "starts the game \"That Number\"" },
            new string[] { "description", "shows rules for each game" },

            new string[] { "Calendar", "show calendar" },

        };

        public void ShowMenu()
        {
            DisplayAvailableCommands();

            do
            {
                Console.WriteLine(HintMessage);
                Console.Write("> ");
                string[] inputs = Console.ReadLine()?.Split(' ', 2);
                const int commandIndex = 0;
                string command = inputs[commandIndex];

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine(HintMessage);
                    continue;
                }

                int index = Array.FindIndex(_commands, 0, _commands.Length, i
                    => i.Item1.Equals(command, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    const int parametersIndex = 1;
                    string parameters = inputs.Length > 1 ? inputs[parametersIndex] : string.Empty;
                    _commands[index].Item2(parameters);
                }
                else
                {
                    PrintMissedCommandInfo(command);
                }
            }
            while (_isRunning);

            Console.WriteLine(HintMessage);
            Console.WriteLine();
        }

        private static void PlayThatNumber(string command)
        {
            Console.Clear();

            Game game = new();
            game.FirstPlayer();
            game.SecondPlayer();
        }

        private static void CreateCalendar(string command)
        {
            Console.Clear();
            var monthLevel = new MonthLevel();
            var createCalendar = new CreateCalendar();
            var calendarDrawer = new CalendarDrawer();
            var specialList = new ListForNotes();
            specialList.UserDay = new List<SpecialDay>();
            var cheker = new MonthLevel();
            bool stillWatch = true;
            while (stillWatch)
            {
                var creater = createCalendar.Create(monthLevel.DaysInWeek, monthLevel.WeeksInMonth, monthLevel.DayNumber,
                    monthLevel.EmptyDays, monthLevel.MonthNumber, monthLevel.Year);
                List<SpecialDay> count = specialList.UserDay.FindAll(cell => cell.Year == creater.Year && cell.Month == creater.MonthNumber);
                if (count.Count != 0)
                {
                    creater = CheckCalendar(specialList, creater, count);
                } 
                calendarDrawer.Draw(creater);
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        Console.Clear();
                        monthLevel.MonthNumber--;
                        if (monthLevel.MonthNumber < 1)
                        {
                            monthLevel.MonthNumber = 12;
                            monthLevel.Year--;
                        }
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        Console.Clear();
                        monthLevel.MonthNumber++;
                        if (monthLevel.MonthNumber > 12)
                        {
                            monthLevel.MonthNumber = 1;
                            monthLevel.Year++;
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        var mess = "\nEnter date in format dd.mm.yyyy:\n";
                        var userDate = EnterDate(mess);
                        Console.Clear();
                        monthLevel.MonthNumber = userDate.Month;
                        monthLevel.Year = userDate.Year;
                        var monthLevelForNote = createCalendar.Create(monthLevel.DaysInWeek, monthLevel.WeeksInMonth, monthLevel.DayNumber,
                        monthLevel.EmptyDays, monthLevel.MonthNumber, monthLevel.Year);

                        if (count.Count != 0)
                        {
                            monthLevelForNote = CheckCalendar(specialList, creater, count);
                        }

                        var noteDay = monthLevelForNote.Month.FindAll(x => x.Symbol == userDate.Day.ToString());
                        Console.Clear();
                        Console.Write($"Your choosed: {userDate.ToShortDateString()}.  \n{noteDay[0].Note}\n\n");
                        Console.Write("Add note for this day?  \nPress \"Y\" or \"N\".\n");
                        var key2 = Console.ReadKey();
                        switch (key2.Key)
                        {
                            case ConsoleKey.Y:
                                Console.Clear();
                                Console.Write("Enter your note: \n");
                                var note = Console.ReadLine();
                                var datee = new SpecialDay()
                                {
                                    Day = userDate.Day,
                                    Month = userDate.Month,
                                    Year = userDate.Year,
                                    Note = note
                                };
                                specialList.UserDay.Add(datee);
                                monthLevel.MonthNumber = DateTime.Now.Month;
                                monthLevel.Year = DateTime.Now.Year;
                                break;
                            case ConsoleKey.N:
                                break;

                        }
                        break;
                    case ConsoleKey.Escape:
                        stillWatch = false;
                        break;

                }
                //условие не выхода месяца за границы от 1 до 12
            }


        }

        public static MonthLevel CheckCalendar(ListForNotes list, MonthLevel create, List<SpecialDay> count1)
        {
            var creater = create;
            var specialList = list;
            List<SpecialDay> count = count1;
            if (count.Count != 0)
            {
                for (int x = 0; x < count.Count; x++)
                {
                    for (int y = 0; y < creater.Month.Count; y++)
                    {
                        if ( count[x].Day.ToString() == create.Month[y].Symbol)
                        {
                            create.Month[y].Note = count[x].Note;
                            create.Month[y].Color = count[x].Color;
                        }
                    }
                }
            }
            return creater;
        }

        private static DateTime EnterDate(string mess)
        {
            DateTime date; 
            string input;
            do
            {
                do
                {
                    Console.WriteLine(mess);
                    input = Console.ReadLine();
                }
                while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out date));
            } while (date.Year < DateTime.Now.Year || date.Month < DateTime.Now.Month);



                return date;
        }

        private static void PlayMaze(string command)
        {
            Console.Clear();

            var builder = new MazeBuilder();
            var drawer = new Drawer();

            //Создали лабиринт
            var maze = builder.Build(27, 15);

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
                    case ConsoleKey.Spacebar:
                        maze.Hero.Fire();
                        break;
                    case ConsoleKey.Escape:
                        wanaPlay = false;
                        break;
                }
            }
        }

        private static void PrintMissedCommandInfo(string command)
        {
            Console.WriteLine($"There is no '{command}' command.");
            Console.WriteLine();
        }

        private static void PrintHelp(string parameters)
        {
            if (!string.IsNullOrEmpty(parameters))
            {
                int index = Array.FindIndex(HelpMessages, 0, HelpMessages.Length, i
                    => string.Equals(i[CommandHelpIndex], parameters, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    Console.WriteLine(HelpMessages[index][ExplanationHelpIndex]);
                }
                else
                {
                    Console.WriteLine($"There is no explanation for '{parameters}' command.");
                }
            }
            else
            {
                Console.WriteLine("Available commands:");

                foreach (var helpMessage in HelpMessages)
                {
                    Console.WriteLine("\t{0}\t- {1}", helpMessage[CommandHelpIndex], helpMessage[DescriptionHelpIndex]);
                }
            }

            Console.WriteLine();
        }

        private static void Exit(string parameters)
        {
            Console.WriteLine("Exiting an application...");
            _isRunning = false;
        }

        private static void ShowGameDescription(string command)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\tThe game \"That Number\" is designed for 2 people." +
                              "\n\tOne person thinks of a number" +
                              "\n\tand the other one ought to guess it having a limited number of attempts.\n");

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tThe game \"Maze\"." +
                              "\n\tThe character should find a way out of the maze." +
                              "\n\tThere are various barriers to his way.");
            Console.ResetColor();
        }

        private static void DisplayAvailableCommands()
        {
            for (int i = 0; i < HelpMessages.Length; i++)
            {
                for (int j = 0; j < HelpMessages[i].Length; j++)
                {
                    Console.Write($"\t * {HelpMessages[i][j],-10}");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
