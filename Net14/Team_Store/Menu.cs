using System;
using System.Collections.Generic;
using System.Text;


namespace Team_Store
{
    public class Menu
    {
        private const string HintMessage = "\n Hello User!\n"+
               "\n  Welcome to WebStore Veishnoria:\n" +
               "    Use keyboard arrows to navigate\n" +
               "    Who are you?\n" +
               "    ****Admin****\n"+
               "    ****Buyer***\n";
        
        private static bool _isRunning = true;

        private readonly Tuple<string, Action<string>>[] _commands = new Tuple<string, Action<string>>[]
         {
            new Tuple<string, Action<string>>("exit", Exit),
            new Tuple<string, Action<string>>("Admin", Admin),
            new Tuple<string, Action<string>>("Buyer", Buyer)
         };
        public void ShowMenu()
        {

           
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

        private static void PrintMissedCommandInfo(string command)
        {
            Console.WriteLine($"There is no '{command}' command.");
            Console.WriteLine();
        }

        private static void Exit(string parameters)
        {
            Console.WriteLine("Exiting an application...");
            _isRunning = false;
        }
        public void Admin()
        {
            var stock = new Stock();
            var starterMessge = "Admin login";
            Console.WriteLine(starterMessge);
           
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Add Goods, 2. Show Stock 3. Exit");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1:

                        stock.Add_Good();

                        break;
                    case ConsoleKey.D2:

                        stock.Show_Stock();
                        Console.ReadKey();
                        break;
                    default:

                        return;
                }
            }
        }
        private static void Admin (string command)
        {
            var stock = new Stock();
         
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n Admin login\n" +
               "    1.Add good\n" +
               "    2.Show_Stock\n" +
               "    3.Exit\n");
                Console.Write("> ");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1:

                        stock.Add_Good();

                        break;
                    case ConsoleKey.D2:

                        stock.Show_Stock();
                        Console.ReadKey();
                        break;
                    default:
                       
                        return;
                }
            }
        }

        private static void Buyer(string command)
        {
            
            while (true)
            {
               
                Console.WriteLine("\n Buyer login\n" +
               "    1.Add good to basket\n" +
               "    2.Filter\n" +
               "    3.Search\n"+
               "    4.Exit\n");
                Console.Write("> ");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        


                        break;
                    case ConsoleKey.D2:

                        
                        Console.ReadKey();
                        break;
                    default:

                        return;
                }
            }
        }
    }
}
