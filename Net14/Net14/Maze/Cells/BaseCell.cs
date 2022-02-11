using Net14.Maze.Cells;
using System;

namespace Net14.Maze
{
    public abstract class BaseCell : ICanStep
    {
        public int X { get; set; }
        public int Y { get; set; }
        public abstract char Symbol { get; }
        public virtual ConsoleColor Color { get; set; } = ConsoleColor.White;
        public virtual ConsoleColor BackColor { get; set; }
        protected MazeLevel _mazeLevel;

        public BaseCell(MazeLevel mazeLevel)
        {
            _mazeLevel = mazeLevel;
        }

        public abstract bool TryToStep(IСharacter hero);

        public override string ToString()
        {
            return $"[{X}, {Y}, '{Symbol}']";
        }
    }
}
