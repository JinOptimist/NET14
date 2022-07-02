using Microsoft.AspNetCore.Mvc;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.EfStuff.Repository;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.Controllers
{
    public class AuthenticationController : Controller
    {
        private UserRepository _userRepository;

        public AuthenticationController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Authentication()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Authentication(UserAuthenticationViewModel user)
        {
            var dbUser = new UserDbModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Email = user.Email,
                Password = user.Password,
                EnglishLevel = user.EnglishLevel
                
            };
            _userRepository.Save(dbUser);

            return RedirectToRoute("default", new { controller = "Home", action = "Index" });
        }
        [HttpGet]
        public IActionResult Autorization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Autorization(UserViewModel user)
        {
            var currentUser = _userRepository.GetByEmailAndPass(user.Email, user.Password);
            
            if(currentUser == null)
            {
                return View();
            }


            return RedirectToRoute("default", new { controller = "Account", action = "MyAccount" });
        }
    }
}