using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using Net14.Maze.Cells;
using Net14.Maze;

namespace Net14.Tests.Maze.Cells
{
    class BLueWallTest
    {
        [Test]
        public void GetSymbol_Test() 
        {
            var mazeMock = new Mock<IMazeLevel>();
            var blueWall = new BlueWall(mazeMock.Object);

            Assert.AreEqual('#', blueWall.Symbol);
        }

        [Test]
        public void TryToStep_Test() 
        {
            var mazeMock = new Mock<IMazeLevel>();
            var blueWall = new BlueWall(mazeMock.Object);
            var characterMock = new Mock<IСharacter>();
            characterMock.SetupProperty(x => x.MessageInMyHead);

            var result = blueWall.TryToStep(characterMock.Object);

            Assert.AreEqual(false, result, "You cant step on blue wall");
            Assert.AreEqual("Boom", characterMock.Object.MessageInMyHead);

        }

        [Test]
        public void GetColor_Test() 
        {
            var mazeMock = new Mock<IMazeLevel>();
            var blueWall = new BlueWall(mazeMock.Object);

            Assert.AreEqual(ConsoleColor.DarkBlue, blueWall.Color);
        }

    }
}
