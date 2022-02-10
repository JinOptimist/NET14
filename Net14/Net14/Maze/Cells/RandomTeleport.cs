using System;

namespace Net14.Maze.Cells
{
    public class RandomTeleport : BaseCell
    {
        public override char Symbol => 'R';
        public override ConsoleColor Color => ConsoleColor.DarkMagenta;

        public override bool TryToStep(Сharacter hero)
        {
            hero.MessageInMyHead = "Teleportation to the random place";
            return true;
        }

        public void ReplaceHero(Сharacter hero)
        {
            Random random = new();

            hero.X = random.Next(0, new MazeLevel().Height); // ЭТО ОЧЕНЬ ПЛОХО - new MazeLevel().Height даст 0,
                                                             // то есть в рандом придет от 0 ДО 0 
            hero.Y = random.Next(0, new MazeLevel().Height);
        }
    }
}
