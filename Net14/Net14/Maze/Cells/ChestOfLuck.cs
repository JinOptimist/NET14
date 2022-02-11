using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    class ChestOfLuck : BaseCell
    {
        public override char Symbol => '■';
        public override ConsoleColor Color => ConsoleColor.DarkYellow;

        public override bool TryToStep(Сharacter hero)
        {
            Random rand = new Random();
            int num = rand.Next(0, 41);

            if (num <= 10)
            {
                hero.Coins++;
                hero.MessageInMyHead = "Wow, it's a coin!!";
            }
            else if (num > 10 && num <= 20)
            {
                hero.Hp++;
                hero.MessageInMyHead = "Wow, it's a medicine!!";

            }
            else if (num > 20 && num <= 30)
            {
                hero.Mood++;
                hero.MessageInMyHead = "Wow, it's a good mood!!";
            }
            else 
            {
                hero.Stamina++;
                hero.MessageInMyHead = "Wow, it's a endurance potion!!";
            }
            return true;
        }
    }
}
