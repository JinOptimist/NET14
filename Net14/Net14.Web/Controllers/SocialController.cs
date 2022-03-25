using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.Repositories;



namespace Net14.Web.Controllers
{
    public class SocialController : Controller

    {
        private SocialUserRepository _socialUserRepository;
        private SocialPostRepository _socialPostRepository;
        public SocialController(SocialUserRepository socialUserRepository, SocialPostRepository socialPostRepository)
        {
            _socialPostRepository = socialPostRepository;
            _socialUserRepository = socialUserRepository;
        }

        public IActionResult Index()
        {
            var postArr = _socialPostRepository.GetAll();
            var viewPost = postArr.Select(post =>
             new SocialPostViewModel()
             {
                 ImageUrl = post.ImageUrl,
                 Comments = post.Comments,
                 UserId = post.User.Id,
                 Likes = post.Likes,
                 TypePost = post.TypePost,
                 NameOfUser = post.User.FirstName,
                 UserPhotoUrl = post.User.UserPhoto


             }).ToList();


            return View(viewPost);
        }

        public IActionResult Settings()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ShowAllUsers()
        {
            var users = _socialUserRepository.GetAll().Select(user =>
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
        public IActionResult ShowAllUsers(string FullName, int Age, string Country, string City, string FirstName, string LastName)
        {

            var userFind = _socialUserRepository.GetBy(FullName, Age, Country, City, FirstName, LastName)
                .Select(user => new SocialUserViewModel()
                {
                    Age = user.Age,
                    City = user.City,
                    Country = user.Country,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Id = user.Id,
                    LastName = user.LastName,
                    UserPhoto = user.UserPhoto
                }).ToList();
            
            return View(userFind);
        }


        public IActionResult AboutUs()
        {
            return View();
        }


        public IActionResult ShowProfile()
        {
            var user = new UserSocial();

            return View(user);
        }

        public IActionResult ShowPagesProfile(int id)
        {

            var user = _socialUserRepository.Get(id);

            var model = new SocialProfileViewModel()
            {
                Age = user.Age,
                FirstName = user.FirstName,
                City = user.City,
                Country = user.Country,
                UserPhoto = user.UserPhoto
            };

            return View(model);
        }
    }
}
