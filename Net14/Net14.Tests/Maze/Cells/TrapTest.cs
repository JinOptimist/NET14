using System;
using Moq;
using Net14.Maze.Cells;
using NUnit.Framework;

namespace Net14.Tests.Maze.Cells
{
    public class TrapTest
    {
        [Test]
        public void TryToStep_CanStep()
        {
            // Подготовка
            var trap = new Trap();
            var heroMock = new Mock<Сharacter>();

            //Действие
            var answer = trap.TryToStep(heroMock.Object);

            //Проверка
            Assert.AreEqual(true, answer, "На клевер МОЖНО наступить");
        }
    }
}
