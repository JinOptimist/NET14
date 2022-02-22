using System;
using System.Collections.Generic;
using System.Text;

namespace TeamSocial.Games
{
    public class GameMath
    {
        private int Points { get; set; }
        private string AnswerIsWrong { get; set; } = "Answer is not correct";
        private string AnswerIsRight { get; set; } = "Answer is correct";
        private int NumberTask { get; set; } = 1;
        private string Task { get; set; } = "Task№ ";

        public void SayHello()
        {
            Console.Clear();
            Console.WriteLine("Hello. It's a game Math");
            Console.WriteLine("You give the correct answer and get points for it");
            Console.WriteLine("Click Enter");
            Console.ReadLine();
        }
        public void Game_Math1()
        {
            Tasks("5 + 5 = ");
            Check(10);
        }
        public void Game_Math2()
        {
            Tasks("2 + 2 * 2 = ");
            Check(6);
        }
        public void Game_Math3()
        {
            Tasks("(44 : 2 + 11) * 20 + 30 * 5 = ");
            Check(810);
        }
        public void Game_Math4()
        {
            Tasks("(5960 – 1320 х 3) : 2 = ");
            Check(1000);
        }
        public void Game_Math5()
        {
            Tasks("(413 * 17 + 97) * 95 : 5");
            Check(135242);
        }
        
        private void Tasks (string task)
        {
            Console.Clear();
            Console.WriteLine(Task + " " + NumberTask + " (Your points: " + Points + ")");
            Console.Write(task);
        }
        private void Check (int answer)
        {
            int result = int.Parse(Console.ReadLine());
            if (result == answer)
            {
                Console.WriteLine(AnswerIsRight);
                Points++;
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
            Console.WriteLine("Your points: " + Points);
        }
    }
}
