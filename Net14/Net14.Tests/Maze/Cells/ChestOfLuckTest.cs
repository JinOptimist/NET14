using NUnit.Framework;
using Net14.Maze.Cells;
using Moq;
using Net14.Maze;
using System;
namespace Net14.Tests.Maze.Cells
{
    public class ChestOfLuckTest
    {
        [Test]
        public void TryToStep()
        {
            // Подготовка
            var mazelevelMock = new Mock<IMazeLevel>();
            var chest = new ChestOfLuck(mazelevelMock.Object);
            var heroMock = new Mock<IСharacter>();

            //Действие
            var answer = chest.TryToStep(heroMock.Object);

            //Проверка
            Assert.AreEqual(true, answer, "На сундук МОЖНО наступить");
        }
        [Test]
        public void Symbol()
        {
            // Подготовка
            var mazelevelMock = new Mock<IMazeLevel>();
            var chestOfLuck = new ChestOfLuck(mazelevelMock.Object);


            //Проверка
            Assert.AreEqual('■', chestOfLuck.Symbol);
        }
        [Test]
        [TestCase(10,10,10,2)]
        [TestCase(1,1,1,1)]
        [TestCase(10, 10, 10, 2, 15)]
        [TestCase(10, 10, 10, 2, 25)]
        [TestCase(10, 10, 10, 2, 35)]
        [TestCase(10, 10, 10, 2, 41)]

        public void TryToStep_AddOneToFeatures(int characterCoins, int characterStamina, 
            int characterHp, int characterMood, int num = 0)
        {
            var mazeLevelMock = new Mock<IMazeLevel>();
            var chestOfLuck = new ChestOfLuck(mazeLevelMock.Object);
            var heroMock = new Mock<IСharacter>();

            heroMock.SetupAllProperties(); //"Активируем все свойства"
            heroMock.Object.Coins = characterCoins;
            heroMock.Object.Stamina = characterStamina;
            heroMock.Object.Hp = characterHp;
            heroMock.Object.Mood = (Mood)characterMood;
            heroMock.Object.MessageInMyHead = "";
            /*Если num передался тесту, то использовать его, 
                а иначе использовать тот, который сгенерируется случайным образом в функции TryToStep()*/
            if (num != 0) 
            {
                chestOfLuck.Num = num;

            }
            var answer = chestOfLuck.TryToStep(heroMock.Object);


            if (heroMock.Object.Coins == ++characterCoins/*Если коины инкрементировались*/
                && (chestOfLuck.Num >= 0 && chestOfLuck.Num <= 10))/*И Num совпдает с условием инкрементации в ChestOfLuck*/
            {
                Assert.AreEqual(heroMock.Object.MessageInMyHead, "Wow, it's a coin!!",//Проверяем правильный ли MessageInMyHead
                    @"MessageInMyHead must be: Wow, it's a coin!!");
            }
            else if (heroMock.Object.Stamina == ++characterStamina
                && (chestOfLuck.Num > 30 && chestOfLuck.Num <= 41))
            {
                Assert.AreEqual(heroMock.Object.MessageInMyHead, "Wow, it's a endurance potion!!",
                    @"MessageInMyHead must be: Wow, it's a endurance potion!!");
            }
            else if (heroMock.Object.Hp == ++characterHp
                && (chestOfLuck.Num > 10 && chestOfLuck.Num <= 20))
            {
                Assert.AreEqual(heroMock.Object.MessageInMyHead, "Wow, it's a medicine!!",
                    @"MessageInMyHead must be: Wow, it's a medicine!!");
            }
            else if ((int)heroMock.Object.Mood == ++characterMood
                && (chestOfLuck.Num > 20 && chestOfLuck.Num <= 30))
            {
                Assert.AreEqual(heroMock.Object.MessageInMyHead, "Wow, it's a good mood!!",
                     @"MessageInMyHead must be: Wow, it's a good mood!!");
            }
            else if (chestOfLuck.Num < 0 || chestOfLuck.Num > (chestOfLuck.CountFeaturesOfCharacter*10) + 1)//Если число вышло за установленные границы
            {
                Assert.Fail($"ChestOfLuck.Num not in range [0, {((chestOfLuck.CountFeaturesOfCharacter * 10) + 1)}], Num was {chestOfLuck.Num}");
            }
            else
            {
                Assert.Fail($"None of the character features were incremented, chestOfLuck was: {chestOfLuck.Num}");
            }

        }
        [Test]
        public void GetColourTest()
        {
            var mazeMock = new Mock<IMazeLevel>();
            var chest = new ChestOfLuck(mazeMock.Object);

            Assert.AreEqual(ConsoleColor.DarkYellow, chest.Color);
        }
    }
}
