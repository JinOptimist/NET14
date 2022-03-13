using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Net14.Web.Controllers
{
    public class SocialController : Controller

    {
        private WebContext _webContext;
        public SocialController(WebContext webContext)
        {
            _webContext = webContext;
        }

        public IActionResult Index()
        {
            var postArr = _webContext.Posts.ToList();
            var viewPost = postArr.Select(post =>
             new SocialPostViewModel()
             {
                 ImageUrl = post.ImageUrl,
                 Comments = post.Comments,
                 UserId = post.UserId,
                 Likes = post.Likes,
                 TypePost = post.TypePost,
                 NameOfUser = _webContext.Users.First(user => user.Id == post.UserId).FirstName,


             }).ToList();


            return View(viewPost);
        }

        public IActionResult ShowSecnodIndex()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ShowAllUsers()
        {
            var users = _webContext.Users.Select(user =>
            new SocialUserViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                Id = user.Id,
                UserPhoto = user.UserPhoto
            }).ToList();



            return View(users);
        }
        [HttpPost]
        public IActionResult ShowAllUsers(string name, int Age, string Country, string City, string FirstName, string LastName)
        {

            if (name == null)
            {
                var user = _webContext.Users.Where(userInDb =>
                    userInDb.Age == (Age == 0 ? userInDb.Age : Age) && 
                    userInDb.City.ToLower() == (City == null ? userInDb.City.ToLower() : City.ToLower()) &&
                    userInDb.Country.ToLower() == (Country == null ? userInDb.Country.ToLower() : Country.ToLower()) &&
                    userInDb.FirstName.ToLower() == (FirstName == null ? userInDb.FirstName.ToLower() : FirstName.ToLower()) &&
                    userInDb.LastName.ToLower() == (LastName == null ? userInDb.LastName.ToLower() : LastName.ToLower()))
                    .Select(user =>
                        new SocialUserViewModel()
                        {
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Age = user.Age,
                            City = user.City,
                            Country = user.Country,
                            Id = user.Id,
                            UserPhoto = user.UserPhoto
                        }).ToList();

                return View(user);
            }
            else 
            {
                string[] names = name.Split(" ");
                if (names.Length == 1)
                {
                    var user = _webContext.Users.Where(user =>
                   user.FirstName.ToLower() == names[0].ToLower() || user.LastName.ToLower() == names[0].ToLower())
                        .Select(foundUser =>
                        new SocialUserViewModel()
                        {
                            FirstName = foundUser.FirstName,
                            LastName = foundUser.LastName,
                            Age = foundUser.Age,
                            City = foundUser.City,
                            Country = foundUser.Country,
                            Id = foundUser.Id,
                            UserPhoto = foundUser.UserPhoto

                        }).ToList();
                    return View(user);
                }
                else if (names.Length == 2) 
                {
                    var user = _webContext.Users.Where(user =>
                    (user.FirstName.ToLower() == names[0].ToLower() && user.LastName.ToLower() == names[1].ToLower())
                        || (user.FirstName.ToLower() == names[1].ToLower() && user.LastName.ToLower() == names[0].ToLower()))
                        .Select(foundUser =>
                        new SocialUserViewModel()
                        {
                        FirstName = foundUser.FirstName,
                        LastName = foundUser.LastName,
                        Age = foundUser.Age,
                        City = foundUser.City,
                        Country = foundUser.Country,
                        Id = foundUser.Id,
                        UserPhoto = foundUser.UserPhoto

                        }).ToList();
                    return View(user);

                }
                return View();
            }
        }


        public IActionResult AboutUs() 
        {
            return View();
        }

    }
}
