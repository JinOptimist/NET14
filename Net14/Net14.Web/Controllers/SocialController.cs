using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            var users = _webContext.Users.ToList();
            var viewPost = postArr.Select(post =>
             new SocialPostViewModel()
             {
                 ImageUrl = post.ImageUrl,
                 Comments = post.Comments,
                 UserId = post.UserId,
                 Likes = post.Likes,
                 TypePost = post.TypePost,
                 NameOfUser = _webContext.Users.First(user => user.Id == post.UserId).FirstName,
                 UserPhotoUrl = users.Single(user => user.Id == post.UserId).UserPhoto


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
        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult Autorisation()
        {
            var user = new UserSocial();
            
            return View(user);
        }
        public IActionResult MyFiles()
        {
            return View();
        }
        public IActionResult AllFiles()
        {
            var files = _webContext.fileSocial.ToList();
            var viewModels = files.Select(db => new FilesViewModel()
            {
                Id = db.Id,
                Name = db.Name,
                Url = db.Url,
                Text = db.Text,
            })
            .ToList();
            return View(viewModels);
        }
        public IActionResult ShowMyFiles(int id)
        {
            var files = _webContext.fileSocial.First(x => x.Id == id);
            var model = new FilesViewModel()
            {
                Name = files.Name,
                Url = files.Url,
                Text = files.Text,
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult AddFiles()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFiles(FilesViewModel viewModel)
        {
            var dbFiles = new FileSocial()
            {
                Name = viewModel.Name,
                Url = viewModel.Url,
                Text = viewModel.Text,
            };
            _webContext.fileSocial.Add(dbFiles);
            _webContext.SaveChanges();                     // Сохраняйся 

            return View();
        }

        [HttpGet]
        public IActionResult ShowPagesProfile()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult ShowPagesProfile(UserSocial user)
        {           
            var model = new UserSocial()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                Id = user.Id,
                UserPhoto = user.UserPhoto
            };
            return View(model);
        }
    }
}
