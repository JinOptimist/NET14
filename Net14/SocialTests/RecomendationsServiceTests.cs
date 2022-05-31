using NUnit.Framework;
using Net14.Web.Services;
using Moq;
using Net14.Web.EfStuff.Repositories;
using AutoMapper;
using Net14.Web.EfStuff.Repositories.SocialRepositories;
using Net14.Web.Models;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System.Collections.Generic;
using Net14.Web.Services.Enums;

namespace SocialTests
{
    [TestFixture]
    public class RecomendationsServiceTests
    {
        private RecomendationsService _recomendationsService;
        const string _commonTag = "DEPECHE MODE";


        private  List<SocialUserRecomendationViewModel> _users = new List<SocialUserRecomendationViewModel>()
        {
            new SocialUserRecomendationViewModel(){Id = 0, Age = 0, City = "Minsk", Country = "Belarus", IsFriend = false, RecomendationRate = 0},
            new SocialUserRecomendationViewModel(){ Id = 1, Age = 10, City = "Grodno", Country = "Russia", IsFriend = true, RecomendationRate = 0}
        };

        private static List<UserSocial> _commonFriends = new List<UserSocial>() { new UserSocial() { Id = 2 } };

        private static List<UserSocial> _dbUsers = new List<UserSocial>()
        {
            new UserSocial() {Id = 0, Age = 0, City = "Minsk", Country = "Belarus", Friends = new List<UserSocial>(_commonFriends)},
            new UserSocial() {Id = 1, Age = 10, City = "Grodno", Country = "Russia"}
        };



        [SetUp]
        public void Setup()
        {
            var socialUserRepository = new Mock<ISocialUserRepository>();
            socialUserRepository.Setup(x => x.GetAll()).Returns(_dbUsers);
            var mapper = new Mock<IMapper>();
            var userService = new Mock<IUserService>();
            userService.Setup(x => x.GetCurrent()).Returns(new UserSocial() { Id = 3, Age = 20, City = "Grodno", Country = "Belarus" });
            var socialGroupRepository = new Mock<ISocialGroupRepository>();
            var socialPostRepository = new Mock<ISocialPostRepository>();


            _recomendationsService = new RecomendationsService(socialUserRepository.Object,
                mapper.Object,
                userService.Object,
                socialGroupRepository.Object,
                socialPostRepository.Object
                );

        }

        [TearDown]
        public void ClearRates() 
        {
            _users.ForEach(user =>
            {
                user.RecomendationRate = 0;
            });
        }

        [Test]
        public void AgeRate_IsCorrect()
        {
            var responce = _recomendationsService.GetAgeRate(_users);
            Assert.AreEqual(0, responce[0].RecomendationRate);
            Assert.AreEqual(5, responce[1].RecomendationRate);
        }
        [Test]
        public void GetCityRate_IsCorrect() 
        {
            var responce = _recomendationsService.GetCityRate(_users);
            Assert.AreEqual(0, responce[0].RecomendationRate);
            Assert.AreEqual(100, responce[1].RecomendationRate);
        }
        [Test]
        public void GetCountryRate_IsCorrect() 
        {
            var responce = _recomendationsService.GetCountryRate(_users);
            Assert.AreEqual(40 ,responce[0].RecomendationRate);
            Assert.AreEqual(0, responce[1].RecomendationRate);
        }

    }
}