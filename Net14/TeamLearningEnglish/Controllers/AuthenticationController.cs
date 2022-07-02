using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Autorization(UserViewModel userViewModel)
        {
            var user = _userRepository
                .GetByEmailAndPass(userViewModel.Email, userViewModel.Password);

            if (user == null)
            {
                return View();
            }

            var claims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("FirstName", (user.FirstName + user.LastName)),
                new Claim(ClaimTypes.AuthenticationMethod, Startup.AuthName)

            }; // it will lie in cookies 

            var identity = new ClaimsIdentity(claims, Startup.AuthName);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);

            return RedirectToRoute("default", new { controller = "Account", action = "MyAccount" });
        }
        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToRoute("default", new { controller = "Home", action = "Index" });
        }
    }
}