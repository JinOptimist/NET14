using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using Net14.Maze.Cells;

namespace Net14.Tests.Maze.Cells
{
    class WallTest1
    {
        [Test]
        public void TryToStep_CanStep() 
        {
            var wall = new Wall();
            var hero = new Mock<IСharacter>();
            var answer = wall.TryToStep(hero.Object);

            Assert.AreEqual(false, answer);
        }

        [Test]
        public void GetSymbol() 
        {
            var wall = new Wall();
            Assert.AreEqual('#', wall.Symbol);
        }
    }
}
