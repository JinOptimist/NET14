using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Net14.Maze.Cells;
using Moq;
using Net14.Maze;

namespace Net14.Tests.Maze.Cells
{
    public class ExitTest
    {
       [Test]
        public void TryToStep_CanStep()
        {
            // Подготовка
            var mazeMock = new Mock<IMazeLevel>();
            var exit = new Exit(mazeMock.Object);
            var heroMock = new Mock<IСharacter>();

            //Действие
            var answer = exit.TryToStep(heroMock.Object);

            //Проверка
            Assert.AreEqual(true, answer, "На выход МОЖНО наступить");
        }
        [Test]
        public void Symbol()
        {
            // Подготовка
            var mazeMock = new Mock<IMazeLevel>();
            var exit = new Exit(mazeMock.Object);
            
            
            //Проверка
            Assert.AreEqual('e', exit.Symbol);
        }
    }
}
