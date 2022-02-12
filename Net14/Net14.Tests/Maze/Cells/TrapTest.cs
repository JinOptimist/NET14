using System;
using Moq;
using Net14.Maze;
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

            var mazeMock = new Mock<IMazeLevel>();
            var trap = new Trap(mazeMock.Object);
            var heroMock = new Mock<IСharacter>();

            //Действие
            var answer = trap.TryToStep(heroMock.Object);

            //Проверка
            Assert.AreEqual(true, answer, "На ловушку МОЖНО наступить");
        }
        [Test]
        [TestCase(2, 1)]
        public void TryToStep_Health(int firstHealth, int secondHealth)
        {
            var mazeMock = new Mock<IMazeLevel>();
            var trap = new Trap(mazeMock.Object);
            var heroMock = new Mock<IСharacter>();
            heroMock.SetupProperty(x => x.Hp);
            heroMock.Object.Hp = firstHealth;
            trap.TryToStep(heroMock.Object);
            Assert.AreEqual(secondHealth, heroMock.Object.Hp);
        }

    }
}
