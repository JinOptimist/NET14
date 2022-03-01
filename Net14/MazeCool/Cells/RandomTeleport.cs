using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace MazeCool.Cells
{
    public class RandomTeleport : BaseCell
    {
        public RandomTeleport(IMazeLevel mazeLevel) : base(mazeLevel)
        {
        }

        public override char Symbol => 'R';
        public override bool TryToStep(IСharacter hero)
        {
            hero.MessageInMyHead = "Teleportation in random plase";
            var GroundForTeleport = _mazeLevel.Cells
                .Where(cell => cell != hero)
                .OfType<Ground>()
                .ToList();
            var RandomTeleportation = new Random();
            var FreeGround = RandomTeleportation.Next(0, GroundForTeleport.Count - 1);
            
            _mazeLevel.Hero.X = GroundForTeleport[FreeGround].X;
            _mazeLevel.Hero.Y = GroundForTeleport[FreeGround].Y;
            
            return false;
        }

    }
}
