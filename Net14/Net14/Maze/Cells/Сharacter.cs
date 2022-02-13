using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
namespace Net14.Maze.Cells
{
    public class Сharacter : BaseCell, IСharacter
    {
        public override char Symbol => 'H';
        public Direction lastDirection { get; set; }
        private ConsoleColor colorOfFire { get; set; } = ConsoleColor.Red;

        private const char VerticalDirectionOfBullet = '|';

        private const char HorizontalDirectionOfBullet = '-';

        public string MessageInMyHead { get; set; }

        public int Coins { get; set; }
        public int Hp { get; set; }
        public Mood Mood { get; set; }
        public int Stamina { get; set; }

        public Сharacter(IMazeLevel mazeLevel) : base(mazeLevel)
        {
        }

        public override bool TryToStep(IСharacter chapter)
        {
            Coins += chapter.Coins;
            return false;
        }

        public void Fire() 
        {

            if (lastDirection == 0 || lastDirection == Direction.Down)
            {
                var destinationX = _mazeLevel.Cells.Where(cell =>
                cell.X == X && cell.Y != Y).OrderBy(cell => cell.Y).Where(cell => cell.Y > Y);
                DrawABullet(VerticalDirectionOfBullet, destinationX);
                

            }
            else if (lastDirection == Direction.Left)
            {
                var destination = _mazeLevel.Cells.Where(cell =>
                cell.Y == Y && cell.X != X).OrderByDescending(cell => cell.X).Where(cell => cell.X < X);
                DrawABullet(HorizontalDirectionOfBullet, destination);


            }
            else if (lastDirection == Direction.Right)
            {
                var direction = _mazeLevel.Cells.Where(cell =>
                cell.Y == Y && cell.X != X).OrderBy(cell => cell.X).Where(cell => cell.X > X);
                DrawABullet(HorizontalDirectionOfBullet, direction);
                

            }
            else if (lastDirection == Direction.Up) 
            {
                var destinationX = _mazeLevel.Cells.Where(cell =>
                cell.X == X && cell.Y != Y && cell.Y < Y).OrderByDescending(cell => cell.Y);
                DrawABullet(VerticalDirectionOfBullet, destinationX);
                

            }

        }

        public void DrawABullet(char direction, IEnumerable<BaseCell> array) 
        {
            foreach (BaseCell cell in array)
            {
                if (cell.GetType() != typeof(Wall))
                {

                    Console.SetCursorPosition(cell.X, cell.Y + 1);
                    Console.ForegroundColor = colorOfFire;
                    Console.Write(direction);
                    Thread.Sleep(100);
                    Console.ForegroundColor = cell.Color;
                    Console.SetCursorPosition(cell.X, cell.Y + 1);
                    Console.Write(cell.Symbol);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Thread.Sleep(420);
                    return;
                }
            }
            Thread.Sleep(420);

        }

    }
}
