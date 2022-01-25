using System;
using System.Collections.Generic;
using System.Text;

namespace Net14
{
    class Program
    {
        static void Main(string[] args)
        {
            // First player
            int min = EnterNumber("Enter min");
            int max = EnterNumber("Enter max");
            int number = EnterNumber("First player enter a number");

            int attemptCountBeforeLoose = CalculateAttemptCount(min, max);

            // Second player
            Console.Clear();
            var usersAttempts = new List<int>();
            var attempt = 0;

            Console.WriteLine("Good day second player");

            int secondNumber = EnterNumber("Second player enter...");

            while (secondNumber != number)
            {
                usersAttempts.Add(secondNumber);
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

                attempt++;

                if (attempt >= attemptCountBeforeLoose)
                {
                    break;
                }

                secondNumber = 
                    EnterNumber($"Attempt: {attempt}/{attemptCountBeforeLoose}. Enter you guess [{min}, {max}]: ");
            }

            if (secondNumber == number)
            {
                Console.WriteLine("Win");
            }
            else
            {
                Console.WriteLine($"Looser. You use more than {attemptCountBeforeLoose}");
            }

            var finalResult = new StringBuilder();
            for (int i = 0; i < usersAttempts.Count; i++)
            {
                var oneAttempt = usersAttempts[i];
                finalResult.Append(oneAttempt + ",");
            }

            Console.WriteLine(finalResult.ToString());
        }

        private static int CalculateAttemptCount(int min, int max)
        {
            var lenght = max - min;

            var attempt = 1;
            var maxLength = 1;

            while (maxLength < lenght)
            {
                attempt++;
                maxLength = maxLength * 2;
            }

            return attempt;
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
