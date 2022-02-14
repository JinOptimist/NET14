using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using Net14.Maze.Cells;
using Net14.Maze;

namespace Net14.Tests.Maze.Cells
{
    class RedWallTest
    {
        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(1)]
        public void TryToStep_CanStep(int hp) 
        {
            var mazeMock = new Mock<IMazeLevel>();
            var redWall = new RedWall(mazeMock.Object);
            var characterMock = new Mock<IСharacter>();
            characterMock.SetupProperty(x => x.Hp);
            characterMock.Object.Hp = hp;

            var answer = redWall.TryToStep(characterMock.Object);


            Assert.AreEqual(false, answer, "You cant step on RedWallClass");
            Assert.AreEqual(--hp, characterMock.Object.Hp);
        }

        [Test]
        public void GetSymbol() 
        {
            var mazeMok = new Mock<IMazeLevel>();
            var wall = new RedWall(mazeMok.Object);
            Assert.AreEqual('#', wall.Symbol);
        }
        [Test]
        public void GetColor_Test() 
        {
            var mazeMock = new Mock<IMazeLevel>();
            var redWall = new RedWall(mazeMock.Object);

            Assert.AreEqual(ConsoleColor.Red, redWall.Color);

        }
    }
}
