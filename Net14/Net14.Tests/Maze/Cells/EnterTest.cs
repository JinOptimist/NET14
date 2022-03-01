using NUnit.Framework;
using MazeCool.Cells;
using Moq;
using MazeCool;

namespace Net14.Tests.Maze.Cells
{
    public class EnterTest
    {
        [Test]
        public void TryToStep_CanStep()
        {
            // Подготовка
            var mazelevelMock = new Mock<IMazeLevel>();
            var enter = new Enter(mazelevelMock.Object);
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
            var mazelevelMock = new Mock<IMazeLevel>();
            var enter = new Enter(mazelevelMock.Object);

            //Проверка
            Assert.AreEqual('x', enter.Symbol);
        }
    }
}
