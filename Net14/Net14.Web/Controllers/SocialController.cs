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
using Microsoft.AspNetCore.Authorization;
using Net14.Web.Services;
using AutoMapper;

namespace Net14.Web.Controllers
{
    public class SocialController : Controller

    {
        private SocialUserRepository _socialUserRepository;
        private SocialPostRepository _socialPostRepository;
        private SocialCommentRepository _socialCommentRepository;
        private UserService _userService;
        private IMapper _mapper;

        public SocialController(SocialUserRepository socialUserRepository, 
            SocialPostRepository socialPostRepository,
            SocialCommentRepository socialCommentRepository,
            UserService userService, IMapper mapper)
        {
            _socialPostRepository = socialPostRepository;
            _socialUserRepository = socialUserRepository;
            _socialCommentRepository = socialCommentRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            var postArr = _socialPostRepository.GetAll();
            var viewPost = _mapper.Map<List<SocialPostViewModel>>(postArr);

            return View(viewPost);
        }

        [Authorize]
        public IActionResult Settings()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ShowAllUsers()
        {
            var users = _socialUserRepository.GetAll();
            var model = _mapper.Map<List<SocialUserViewModel>>(users);

            return View(model);
        }

        [HttpPost]
        public IActionResult ShowAllUsers(string FullName, int Age, string Country, string City, string FirstName, string LastName)
        {

            var users = _socialUserRepository.GetBy(FullName, Age, Country, City, FirstName, LastName);
            var model = _mapper.Map<List<SocialUserViewModel>>(users);

            return View(model);
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
            var model = _mapper.Map<SocialProfileViewModel>(user);
     
            return View(model);
        }

        [Authorize]
        public IActionResult MyProfile()
        {
            var user = _userService.GetCurrent();
            var model = _mapper.Map<SocialProfileViewModel>(user);

            return View(model);
        }

        [Authorize]
        public IActionResult AddComment(int postId, string text)
        {
            if (text == null)
            {
                return RedirectToAction("Index");
            }
            var post = _socialPostRepository.Get(postId);
            var currentUser = _userService.GetCurrent();

            var comment = new SocialComment()
            {
                Post = post,
                Text = text,
                User = currentUser
            };

            _socialCommentRepository.Save(comment);
            return RedirectToAction("Index");
        }
    }
}
