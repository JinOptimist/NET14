using MazeCool;
using MazeCool.Cells;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Net14.Tests.Maze.Cells
{
    public class ChestCoinTest
    {
        [Test]
        public void Symbol()
        {
            // Подготовка
            var mazeMock = new Mock<IMazeLevel>();
            var chestCoin = new ChestCoin(mazeMock.Object);


            //Проверка
            Assert.AreEqual('@', chestCoin.Symbol);
        }
        [Test]
        public void Color()
        {
            // Подготовка
            var mazeMock = new Mock<IMazeLevel>();
            var chestCoin = new ChestCoin(mazeMock.Object);


            //Проверка
            Assert.AreEqual(ConsoleColor.Yellow, chestCoin.Color);
        }
        [Test]
        public void TryToStep_CanStep()
        {
            // Подготовка
            var mazeMock = new Mock<IMazeLevel>();
            var chestCoin = new ChestCoin(mazeMock.Object);
            var heroMock = new Mock<IСharacter>();

            //Действие
            var answer = chestCoin.TryToStep(heroMock.Object);

            //Проверка
            Assert.AreEqual(true, answer, "На Монету можно наступить");
        }
        [Test]
        [TestCase(10, 5, 15)]
        [TestCase(0, 1, 1)]
        [TestCase(5, 7, 12)]
        public void TryToStep_GetMoney(int chestCount, int heroInitCoins, int finalCoins)
        {
            // Подготовка
            var mazeMock = new Mock<IMazeLevel>();
            var chestCoin = new ChestCoin(mazeMock.Object);
            chestCoin.CoinsCount = chestCount;

            var heroMock = new Mock<IСharacter>();
            heroMock.SetupProperty(x => x.Coins);
            heroMock.Object.Coins = heroInitCoins;

            //Действие
            chestCoin.TryToStep(heroMock.Object);

            //Проверка
            Assert.AreEqual(finalCoins, heroMock.Object.Coins);
        }
    }
}
