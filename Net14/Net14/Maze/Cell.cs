using System;

namespace Net14.Maze
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }
        public ConsoleColor BackColor { get; set; }

        public override string ToString()
        {
            return $"[{X}, {Y}, '{Symbol}']";
        }
    }
}