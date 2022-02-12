using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Net14.Maze.Cells;
using Moq;
using Net14.Maze;

namespace Net14.Tests.Maze.Cells
{
    public class EnterTest
    {
        [Test]
        public void TryToStep_CanStep()
        {
            // Подготовка
            var mazeMock = new Mock<IMazeLevel>();
            var enter = new Enter(mazeMock.Object);
            var heroMock = new Mock<IСharacter>();

            //Действие
            var answer = enter.TryToStep(heroMock.Object);

            //Проверка
            Assert.AreEqual(true, answer, "На вход МОЖНО наступить");
        }
        [Test]
        public void Symbol()
        {
            // Подготовка
            var mazeMock = new Mock<IMazeLevel>();
            var enter = new Enter(mazeMock.Object);


            //Проверка
            Assert.AreEqual('x', enter.Symbol);
        }
    }
}
