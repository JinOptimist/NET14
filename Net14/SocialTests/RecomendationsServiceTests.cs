using NUnit.Framework;
using Net14.Web.Services;
using Moq;
using Net14.Web.EfStuff.Repositories;
using AutoMapper;
using Net14.Web.EfStuff.Repositories.SocialRepositories;

namespace SocialTests
{
    [TestFixture]
    public class RecomendationsServiceTests
    {
        private RecomendationsService _recomendationsService;

        [SetUp]
        public void Setup()
        {
            var socialUserRepository = new Mock<ISocialUserRepository>();
            var mapper = new Mock<IMapper>();
            var userService = new Mock<IUserService>();
            var socialGroupRepository = new Mock<ISocialGroupRepository>();
            var socialPostRepository = new Mock<ISocialPostRepository>();

            _recomendationsService = new RecomendationsService(socialUserRepository.Object,
                mapper.Object,
                userService.Object,
                socialGroupRepository.Object,
                socialPostRepository.Object
                ); 
        }

        [Test]
        public void Test1()
        {

            Assert.Pass();
        }
    }
}