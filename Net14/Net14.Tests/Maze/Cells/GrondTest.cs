using NUnit.Framework;
using MazeCool.Cells;
using Moq;
using MazeCool;
using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Tests.Maze.Cells
{
    public class GroundTest
    {
        [Test]
        public void TryToStep_CanStep()
        {
            // Подготовка
            var mazeMock = new Mock<IMazeLevel>();
            var ground = new Ground(mazeMock.Object);
            var heroMock = new Mock<IСharacter>();

            //Действие
            var answer = ground.TryToStep(heroMock.Object);

            //Проверка
            Assert.AreEqual(true, answer, "На землю МОЖНО наступить");
        }
        [Test]
        public void Symbol()
        {
            // Подготовка
            var mazeMock = new Mock<IMazeLevel>();
            var ground = new Ground(mazeMock.Object);


            //Проверка
            Assert.AreEqual('.', ground.Symbol);
        }
    }
}
