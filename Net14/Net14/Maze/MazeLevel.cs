using Net14.Maze.Cells;
using System.Collections.Generic;
using System.Linq;

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

            if (destinationCell.Symbol == new ChestCoin().Symbol)
            {
                Hero.Coins++;

                ReplaceCell(new Ground { X = destinationX, Y = destinationY });
            }
            
            if (destinationCell.Symbol == '*')
            {
                var mood = (int)Hero.Mood;
                if (mood < 5)
                {
                    Hero.Mood++;
                }

                ReplaceCell(new Ground()
                {
                    X = destinationX,
                    Y = destinationY
                });
            }

            RandomTeleport teleport = new RandomTeleport();
            if (destinationCell.Symbol == teleport.Symbol)
            {
                teleport.ReplaceHero(Hero);

                ReplaceCell(new Ground { X = destinationX, Y = destinationY });

                // тут (наверное) надо не только R превращать в землю, а переносить телепорт в новое место - но это мои предположения
            }
        }
    }
}
