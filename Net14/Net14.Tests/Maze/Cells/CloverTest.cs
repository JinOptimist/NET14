using Moq;
using Net14.Maze.Cells;
using NUnit.Framework;
using System;

namespace Net14.Tests.Maze.Cells
{
    public class CloverTest
    {
        [Test]
        public void TryToStep_CanStep()
        {
            // Подготовка
            var clover = new Clover();
            var heroMock = new Mock<Сharacter>();

            //Действие
            var answer = clover.TryToStep(heroMock.Object);

            //Проверка
            Assert.AreEqual(true, answer, "На клевер МОЖНО наступить");
        }

        [Test]
        [TestCase(10, 5, 15)]
        [TestCase(0, 1, 1)]
        [TestCase(5, 7, 12)]
        public void TryToStep_GetMoney(int cloverCount, int heroInitCoins, int finalCoins)
        {
            // Подготовка
            var clover = new Clover();
            clover.CloverCount = cloverCount;

            var heroMock = new Mock<IСharacter>();
            heroMock.SetupProperty(x => x.Coins);
            heroMock.Object.Coins = heroInitCoins;

            //Действие
            clover.TryToStep(heroMock.Object);

            //Проверка
            Assert.AreEqual(finalCoins, heroMock.Object.Coins);
        }
    }
}
