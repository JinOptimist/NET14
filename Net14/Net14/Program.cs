using System;

namespace Net14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");

            var name = Console.ReadLine();

            Console.WriteLine($"Hi {name} nice to see you.");

            int number = EnterNumber("First player enter a number");

            Console.Clear();

            Console.WriteLine("Good day second player");

            int secondNumber = EnterNumber("Second player enter...");

            while (secondNumber != number)
            {
                if (number > secondNumber)
                {
                    // true
                    Console.WriteLine(">");
                }
                else
                {
                    // false
                    Console.WriteLine("<");
                }

                secondNumber = EnterNumber("Second player enter...");
            }

            Console.WriteLine("Win");


        }

        private static int EnterNumber(string message)
        {
            Console.WriteLine(message);
            var numberString = Console.ReadLine();
            int number = Int32.Parse(numberString);

            return number;
        }
    }
}
