using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Maze.Cells
{
    public class Сharacter : BaseCell
    {
        public override char Symbol => 'H';

        public string MessageInMyHead { get; set; }

        // public string Happiness { get; set; }

        public int Coins { get; set; }
        public int Hp { get; set; }
        public Mood Mood { get; set; }
        public int Stamina { get; set; }

        public override bool TryToStep(Сharacter chapter)
        {
            Coins += chapter.Coins;
            return false;
        }

    }
}
