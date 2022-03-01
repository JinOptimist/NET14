using Moq;
using MazeCool;
using MazeCool.Cells;
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
            var mazeMock = new Mock<IMazeLevel>();
            var clover = new Clover(mazeMock.Object);
            var heroMock = new Mock<IСharacter>();

            //Действие
            var answer = clover.TryToStep(heroMock.Object);

            //Проверка
            Assert.AreEqual(true, answer, "На клевер МОЖНО наступить");
        }

        [Test]
        [TestCase(3, 7, 10)]
        [TestCase(0, 5, 5)]
        [TestCase(8, 3, 11)]
        public void TryToStep_GetMoney(int cloverCount, int heroInitCoins, int finalCoins)
        {
            // Подготовка
            var mazeMock = new Mock<IMazeLevel>();
            var clover = new Clover(mazeMock.Object);
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
