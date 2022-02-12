using Moq;
using Net14.Maze;
using Net14.Maze.Cells;
using NUnit.Framework;
using System;

namespace Net14.Tests.Maze.Cells
{
    public class TrapTest
    {
        [Test]
        public void TryToStep_CanStep()
        {
            // Подготовка
            var mazelevelMock = new Mock<IMazeLevel>();
            var trap = new Trap(mazelevelMock.Object);
            var heroMock = new Mock<IСharacter>();

            //Действие
            var answer = trap.TryToStep(heroMock.Object);

            //Проверка
            Assert.AreEqual(true, answer, "На ловушку МОЖНО наступить (но не стоит)");
        }
        [Test]
        [TestCase(2, 1)]
        [TestCase(7, 6)]
        [TestCase(545, 544)]
        public void TryToStep_LoseHealth(int starterHealth, int finalHealth)
        {
            // Подготовка
            var mazelevelMock = new Mock<IMazeLevel>();
            var trap = new Trap(mazelevelMock.Object);

            var heroMock = new Mock<IСharacter>();
            heroMock.SetupProperty(x => x.Hp);
            heroMock.Object.Hp = starterHealth;

            //Действие
            trap.TryToStep(heroMock.Object);

            //Проверка
            Assert.AreEqual(finalHealth, heroMock.Object.Hp);
        }
    }
}
