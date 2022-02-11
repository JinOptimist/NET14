using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using Net14.Maze.Cells;
using Net14.Maze;

namespace Net14.Tests.Maze.Cells
{
    class WallTest1
    {
        [Test]
        public void TryToStep_CanStep() 
        {
            var mazeMok = new Mock<IMazeLevel>();
            var wall = new Wall(mazeMok.Object);
            var hero = new Mock<IСharacter>();
            var answer = wall.TryToStep(hero.Object);

            Assert.AreEqual(false, answer);
        }

        [Test]
        public void GetSymbol() 
        {
            var mazeMok = new Mock<IMazeLevel>();
            var wall = new Wall(mazeMok.Object);
            Assert.AreEqual('#', wall.Symbol);
        }
    }
}
