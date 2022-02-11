using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Net14.Maze.Cells;
using Moq;

namespace Net14.Tests.Maze.Cells
{
    public class ExitTest
    {
       [Test]
        public void TryToStep_CanStep()
        {
            // Подготовка
            var exit = new IExit();
            var heroMock = new Mock<Сharacter>();

            //Действие
            var answer = exit.TryToStep(heroMock.Object);

            //Проверка
            Assert.AreEqual(true, answer, "На выход МОЖНО наступить");
        }
        [Test]
        public void Symbol()
        {
            // Подготовка
            var exit = new Exit();
            
            
            //Проверка
            Assert.AreEqual('e', exit.Symbol);
        }
    }
}
