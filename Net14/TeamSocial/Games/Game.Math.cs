using System;
using System.Collections.Generic;
using System.Text;

namespace TeamSocial.Games
{
    public class Game1
    {
        private int Ball { get; set; }
        private string AnswerIsWrong { get; set; } = "Ответ не верный";
        private string AnswerIsRight { get; set; } = "Ответ верный";
        private int NumberTask { get; set; } = 1;
        private string Task { get; set; } = "Task№ ";
        
        
        public void Game_Math1()
        {
            Console.Clear();
            Console.WriteLine("Приветствую тебя в игре Game 1");
            Console.WriteLine("Ты решаешь математические задачки и получаешь за это балы");
            Console.WriteLine(Task + " " + NumberTask + " (Ваше количество баллов: " + Ball + ")");
            Console.Write("5 + 5 = ");
            int result = int.Parse(Console.ReadLine());
            if (result == 10)
            {
                Console.WriteLine(AnswerIsRight);
                Ball++;
                NumberTask++;
            }
            else
            {
                Console.WriteLine(AnswerIsWrong);
            }
            Console.ReadLine();
        }
        public void Game_Math2()
        {
            Console.Clear();
            Console.WriteLine(Task + " " + NumberTask + " (Ваше количество баллов: " + Ball + ")");
            Console.Write("2 + 2 * 2 = ");
            int result = int.Parse(Console.ReadLine());
            if (result == 6)
            {
                Console.WriteLine(AnswerIsRight);
                Ball++;
                NumberTask++;
            }
            else
            {
                Console.WriteLine(AnswerIsWrong);
            }
            Console.ReadLine();
        }
        public void Game_Math3()
        {
            Console.Clear();
            Console.WriteLine(Task + " " + NumberTask + " (Ваше количество баллов: " + Ball + ")");
            Console.Write("(44 : 2 + 11) * 20 + 30 * 5 = ");
            int result = int.Parse(Console.ReadLine());
            if (result == 810)
            {
                Console.WriteLine(AnswerIsRight);
                Ball++;
                NumberTask++;
            }
            else
            {
                Console.WriteLine(AnswerIsWrong);
            }
            Console.ReadLine();
        }
        public void Game_Math4()
        {
            Console.Clear();
            Console.WriteLine(Task + " " + NumberTask + " (Ваше количество баллов: " + Ball + ")");
            Console.Write("(5960 – 1320 х 3) : 2 = ");
            int result = int.Parse(Console.ReadLine());
            if (result == 1000)
            {
                Console.WriteLine(AnswerIsRight);
                Ball++;
                NumberTask++;
            }
            else
            {
                Console.WriteLine(AnswerIsWrong);
            }
            Console.ReadLine();
        }
        public void Game_Math5()
        {
            Console.Clear();
            Console.WriteLine(Task + " " + NumberTask + " (Ваше количество баллов: " + Ball + ")");
            Console.Write("(413 * 17 + 97) * 95 : 5");
            int result = int.Parse(Console.ReadLine());
            if (result == 135242)
            {
                Console.WriteLine(AnswerIsRight);
                Ball++;
                NumberTask++;
            }
            else
            {
                Console.WriteLine(AnswerIsWrong);
            }
            Console.ReadLine();
        }
        public void PrintResult()
        {
            Console.Clear();
            Console.WriteLine("Ваша суммарное количество очков: "+ Ball);
        }
    }
}
