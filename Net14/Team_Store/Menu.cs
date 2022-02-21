using System;
using System.Collections.Generic;
using System.Text;


namespace Team_Store
{
    public class Menu
    {
        public void Start()
        {
            var stock = new Stock();



            while (true)
            {
                //Console.ReadKey();
                var starterMessge =
               "\n  WebStore Veishnoria:\n" +
               "    Use keyboard arrows to navigate\n" +
               "    Enter - select category\n" +
               "    Esc - leave current category\n";
                Console.WriteLine(starterMessge);
                Console.WriteLine("1. Add Goods, 2. Show Stock 3. SortByCategory 9.Exit");


                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1:

                        Console.WriteLine();
                        stock.Add_Good();
                        Console.Clear();

                        break;
                    case ConsoleKey.D2:

                        Console.WriteLine();
                        stock.Show_Stock();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.D3:

                        Console.WriteLine();
                        stock.SortByCategory();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.D9:

                        Console.WriteLine();


                        return;
                }
            }
        }

    }
}