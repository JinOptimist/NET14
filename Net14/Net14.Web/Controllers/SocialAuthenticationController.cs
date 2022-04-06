using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.Repositories;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Net14.Web.Controllers
{
    public class SocialAuthenticationController : Controller

    {
        private SocialUserRepository _socialUserRepository;
        public SocialAuthenticationController(SocialUserRepository socialUserRepository)
        {
            _socialUserRepository = socialUserRepository;
        }


        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(SocialUserRegistrationViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userDb = new UserSocial()
                {
                    Age = user.Age,
                    City = user.City,
                    Country = user.Country,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = user.Password,
                };
                _socialUserRepository.Save(userDb);

                return RedirectToRoute("default", new { controller = "Social", action = "ShowPagesProfile", id = userDb.Id });
            }
            else
            {
                return View();

            }
        }
        [HttpGet]
        public IActionResult Autorization(string ReturnUrl)
        {
            var model = new SocialUserAutorizationViewModel()
            {
                ReturnUrl = ReturnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Autorization(SocialUserAutorizationViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = _socialUserRepository.GetByEmAndPass(userViewModel.Email, userViewModel.Password);

            if (user == null)
            {
                return View();
            }

            //good

            var claims = new List<Claim>() {
                new Claim("Id", user.Id.ToString()),
                new Claim("Name", user.FirstName),
                new Claim(ClaimTypes.AuthenticationMethod, Startup.AuthName)
            };

            var identity = new ClaimsIdentity(claims, Startup.AuthName);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);

            if (userViewModel.ReturnUrl == null) 
            {
                return RedirectToRoute("default", new { controller = "Social", action = "ShowPagesProfile", id = user.Id });
            }
            return Redirect(userViewModel.ReturnUrl);
        }
    }
}
