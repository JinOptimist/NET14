using Net14.Maze.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net14.Maze
{
    public class MazeLevel
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Сharacter Hero { get; set; }

        public List<BaseCell> Cells { get; set; }

        public void ReplaceCell(BaseCell cell)
        {
            var oldCell = Cells.Single(c => c.X == cell.X && c.Y == cell.Y);

            Cells.Remove(oldCell);

            Cells.Add(cell);
        }

        internal void Move(Direction left)
        {
            Hero.MessageInMyHead = "";

            var destinationX = Hero.X;
            var destinationY = Hero.Y;

            switch (left)
            {
                case Direction.Left:
                    destinationX--;
                    break;
                case Direction.Right:
                    destinationX++;
                    break;
                case Direction.Up:
                    destinationY--;
                    break;
                case Direction.Down:
                    destinationY++;
                    break;
                default:
                    break;
            }

            var destinationCell = Cells
                .SingleOrDefault(c => 
                    c.X == destinationX
                     && c.Y == destinationY);

            if (destinationCell == null)
            {
                return;
            }

            if (destinationCell.TryToStep(Hero))
            {
                Hero.X = destinationX;
                Hero.Y = destinationY;
            }
            if(destinationCell.Symbol=='*')
            {
                Hero.Mood++;
                ReplaceCell(new Ground()
                {
                X = destinationX,
                Y = destinationY
               
            }); 
            }
        }
    }
}
