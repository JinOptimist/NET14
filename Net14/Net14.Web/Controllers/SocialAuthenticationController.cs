using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;



namespace Net14.Web.Controllers
{
    public class SocialAuthenticationController : Controller

    {
        private WebContext _webContext;
        public SocialAuthenticationController(WebContext webContext)
        {
            _webContext = webContext;
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
                    Email = user.Email,
                    Password = user.Password,
                    Age = user.Age,
                    City = user.City,
                    Country = user.Country,
                    FirstName = user.FirstName,
                    LastName = user.LastName,

                };
                _webContext.Users.Add(userDb);
                _webContext.SaveChanges();
                return Redirect("~/Social/ShowPagesProfile");

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
                var users = _webContext.Users.ToArray();
                var currentUser = users.SingleOrDefault(us =>
                us.Email == user.Email &&
                us.Password == user.Password);
                if (currentUser == null)
                {
                    return View();
                }
                else 
                {
                    return Redirect("/Social/ShowProfile");
                }
            }
            else 
            {
                return View();
            }
        }
    }
}
