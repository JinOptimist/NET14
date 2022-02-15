using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class ChestOfLuck : BaseCell
    {
        public int Num { set; get; } = 0;
        public override char Symbol => '■';
        public override ConsoleColor Color => ConsoleColor.DarkYellow;

        public int CountFeaturesOfCharacter { get; set; } = 4;
        

        public ChestOfLuck(IMazeLevel mazeLevel) : base(mazeLevel)
        {
        }
        public override bool TryToStep(IСharacter hero)
        {
            Random rand = new Random();
            if (Num == 0) 
            {
                Num = rand.Next(0, (CountFeaturesOfCharacter*10) + 1);

            }

            if (Num <= 10)
            {
                hero.Coins++;
                hero.MessageInMyHead = "Wow, it's a coin!!";
            }
            else if (Num > 10 && Num <= 20)
            {
                hero.Hp++;
                hero.MessageInMyHead = "Wow, it's a medicine!!";

            }
            else if (Num > 20 && Num <= 30)
            {
                hero.Mood++;
                hero.MessageInMyHead = "Wow, it's a good mood!!";
            }
            else if(Num > 30 && Num <= 41) 
            {
                hero.Stamina++;
                hero.MessageInMyHead = "Wow, it's a endurance potion!!";
            }
            _mazeLevel.ReplaceCell(new Ground(_mazeLevel)
            {
                X = X,
                Y = Y
            });
            return true;
        }
    }
}
