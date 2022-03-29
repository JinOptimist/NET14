using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.Repositories;



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
        public IActionResult Registration(SocialUserRegistration user)
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
        public IActionResult Autorization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Autorization(SocialUserAutorization user) 
        {
            if (ModelState.IsValid)
            {
                var users = _socialUserRepository.GetByEmAndPass(user.Email, user.Password);

                if (users == null)
                {
                    return View();
                }
                else 
                {
                    return RedirectToRoute("default", new { controller = "Social", action = "ShowPagesProfile", id = users.Id});

                }
            }
            else 
            {
                return View();
            }
        }
    }
}
