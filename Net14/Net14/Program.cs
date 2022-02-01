using System;
using System.Collections.Generic;
using System.Text;

namespace Net14
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add new comment
            var game = new Game();
            game.FirstPlayer();
            game.SecondPlayer();
        }
    }
}
