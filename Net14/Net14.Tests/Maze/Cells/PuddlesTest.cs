using NUnit.Framework;
using Net14.Maze.Cells;
using Moq;
using Net14.Maze;
using System;

namespace Net14.Tests.Maze.Cells
{
    public class PuddleTest
    {
        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(1)]
        public void TryToStep_CanStep(int stamina)
        {
            // Подготовка
            var mazelevelMock = new Mock<IMazeLevel>();
            var puddle = new Puddles(mazelevelMock.Object);
            var heroMock = new Mock<IСharacter>();
            heroMock.SetupProperty(x => x.Stamina);
            heroMock.Object.Stamina = stamina;
            //Действие
            var answer = puddle.TryToStep(heroMock.Object);

            //Проверка
            Assert.AreEqual(true, answer, "You can step on puddles!");
            Assert.AreEqual(--stamina, heroMock.Object.Stamina);
        }
        [Test]
        public void Symbol()
        {
            // Подготовка
            var mazelevelMock = new Mock<IMazeLevel>();
            var puddle = new Puddles(mazelevelMock.Object);
            var ground = new Ground(mazelevelMock.Object);


            //Проверка
            Assert.AreEqual(ground.Symbol, puddle.Symbol);
        }

        [Test]
        public void GetBackColor() 
        {
            var mazeMock = new Mock<IMazeLevel>();
            var puddle = new Puddles(mazeMock.Object);

            Assert.AreEqual(ConsoleColor.DarkBlue, puddle.BackColor);
        }
    }
}
