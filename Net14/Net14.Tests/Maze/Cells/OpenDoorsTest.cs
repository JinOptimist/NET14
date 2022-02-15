using Moq;
using Net14.Maze;
using Net14.Maze.Cells;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Tests.Maze.Cells
{
    public class OpenDoorsTest
    {
        [Test]
        public void TryToStep_CanStep()
        {
            // Подготовка
            var mazeMock = new Mock<IMazeLevel>();
            var openDoors = new OpenDoors(mazeMock.Object);
            var heroMock = new Mock<IСharacter>();

            //Действие
            var answer = openDoors.TryToStep(heroMock.Object);

            //Проверка
            Assert.AreEqual(true, answer);
        }
        [Test]
        public void Symbol()
        {
            // Подготовка
            var mazeMock = new Mock<IMazeLevel>();
            var openDoors = new OpenDoors(mazeMock.Object);


            //Проверка
            Assert.AreEqual('/', openDoors.Symbol);
        }
    }
}
