using System;
using System.Collections.Generic;
using System.Text;

namespace Net14
{
    class Game
    {
        private GameRule Rule { get; set; }
        private List<int> UsersAttempts { get; set; } = new List<int>();
        private int SecondPlayerAttempts { get; set; }
        private int SecondPlayerNumber { get; set; }

        public void FirstPlayer()
        {
            int min = EnterNumber("Enter min");
            int max = EnterNumber("Enter max");
            int number = EnterNumber("First player enter a number");
            int attemptCountBeforeLoose = CalculateAttemptCount(min, max);

            Rule = new GameRule()
            {
                Min = min,
                Max = max,
                Number = number,
                AttemptCountBeforeLoose = attemptCountBeforeLoose
            };
        }

        public void SecondPlayer()
        {
            //one more comments
            Console.Clear();
            Console.WriteLine("Good day second player!?");

            do
            {
                SecondPlayerTryToGuess();
            } while (SecondPlayerNumber != Rule.Number);

            CheckGameResult();
        }

        private void SecondPlayerTryToGuess()
        {
            SecondPlayerNumber =
                EnterNumber($"Attempt: {SecondPlayerAttempts}/{Rule.AttemptCountBeforeLoose}. " +
                $"Enter you guess [{Rule.Min}, {Rule.Max}]: ");
            
            UsersAttempts.Add(SecondPlayerNumber);

            if (Rule.Number > SecondPlayerNumber)
            {
                Console.WriteLine(">");
            }
            if (Rule.Number < SecondPlayerNumber)
            {
                Console.WriteLine("<");
            }

            SecondPlayerAttempts++;
        }

        private void CheckGameResult()
        {
            if (SecondPlayerNumber == Rule.Number)
            {
                Console.WriteLine("Win");
            }
            else
            {
                Console.WriteLine($"Looser. You use more than {Rule.AttemptCountBeforeLoose}");
            }

            var finalResult = new StringBuilder();
            for (int i = 0; i < UsersAttempts.Count; i++)
            {
                var oneAttempt = UsersAttempts[i];
                finalResult.Append(oneAttempt + ",");
            }

            Console.WriteLine(finalResult.ToString());
        }
        
        private int EnterNumber(string message)
        {
            Console.WriteLine(message);
            var numberString = Console.ReadLine();
            int number = Int32.Parse(numberString);

            return number;
        }

        private int CalculateAttemptCount(int min, int max)
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


    }
}
