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
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Net14.Web.Controllers.AutorizeAttribute;
using Microsoft.AspNetCore.SignalR;
using Net14.Web.SignalRHubs;
using Net14.Web.Models.SocialModels.Attributes;
using System.Reflection;

namespace Net14.Web.Controllers
{
    public class SocialController : Controller

    {
        private SocialUserRepository _socialUserRepository;
        private SocialPostRepository _socialPostRepository;
        private UserService _userService;
        private IMapper _mapper;
        private RecomendationsService _recomendationsService;

        public SocialController(SocialUserRepository socialUserRepository,
            SocialPostRepository socialPostRepository,
            UserService userService, IMapper mapper,
            RecomendationsService recomendationsService)
        {
            _socialPostRepository = socialPostRepository;
            _socialUserRepository = socialUserRepository;
            _userService = userService;
            _mapper = mapper;
            _recomendationsService = recomendationsService;
        }
        [HttpGet]
        public IActionResult Index()
        {

            var postArr = _socialPostRepository.GetAll();
            var topThree = _mapper.Map<List<SocialPostViewModel>>(_recomendationsService.GetIndexRecomendations());
            var viewPost = _mapper.Map<List<SocialPostViewModel>>(postArr);


            var finalModel = new SocialPostWithTopViewModel()
            {
                Posts = viewPost,
                TopThreePost = topThree
            };

            return View(finalModel);
        }

        [HttpPost]
        public IActionResult Index(string ImageUrl, string CommentOfUser)
        {
            var user = _userService.GetCurrent();
            var post = new PostSocial()
            {
                CommentOfUser = CommentOfUser,
                ImageUrl = ImageUrl,
                User = user
            };
            _socialPostRepository.Save(post);

            return Redirect("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Settings()
        {
            var currentUser = _userService.GetCurrent();
            var model = _mapper.Map<SocialUserSettingsViewModel>(currentUser);

            return View(model);
        }

        [HttpPost]
        public IActionResult Settings(SocialUserSettingsViewModel socialUserSettingsViewModel)
        {
            if (ModelState.IsValid)
            {
                var currentUser = _userService.GetCurrent();

                currentUser.Age = socialUserSettingsViewModel.Age;
                currentUser.City = socialUserSettingsViewModel.City;
                currentUser.Country = socialUserSettingsViewModel.Country;
                currentUser.FirstName = socialUserSettingsViewModel.FirstName;
                currentUser.LastName = socialUserSettingsViewModel.LastName;

                _socialUserRepository.Save(currentUser);
            }

            return RedirectToAction("Settings");
        }
        [HttpGet]
        public IActionResult ShowAllUsers()
        {
            var currentUser = _userService.GetCurrent();
            var dbUsers = _socialUserRepository.GetAll();

            if (currentUser == null)
            {
                var model = _mapper.Map<List<SocialUserViewModel>>(dbUsers);
                return View(model);

            }

            var modelNoCurrent = dbUsers.Where(user => user.Id != currentUser.Id)
                .Select(db =>
                {
                    if (currentUser.Friends.Contains(db))
                    {
                        var mod = _mapper.Map<SocialUserViewModel>(db);
                        mod.IsFriend = true;
                        return mod;
                    }
                    if (currentUser.FriendRequestSent.Exists(req => req.Receiver.Id == db.Id && req.FriendRequestStatus == FriendRequestStatus.Pending))
                    {
                        var mod = _mapper.Map<SocialUserViewModel>(db);
                        mod.IsRequested = true;
                        return mod;
                    }
                    var modNotFriend = _mapper.Map<SocialUserViewModel>(db);
                    return modNotFriend;

                }).ToList();


            return View(modelNoCurrent);
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

        public IActionResult ShowPagesProfile()
        {
            var postUser = _mapper.Map<List<SocialPostViewModel>>(_userService.GetCurrent().Posts);
            var user = _userService.GetCurrent();
            var model = _mapper.Map<SocialProfileViewModel>(user);
            model.UserPost = postUser;

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
        public IActionResult Friends()
        {
            var currentUser = _userService.GetCurrent();

            var friends = currentUser.Friends;

            var model = _mapper.Map<List<SocialUserViewModel>>(friends);

            return View(model);
        }

        [Authorize]
        [HasRole(SiteRole.Admin)]
        public IActionResult GetAPIs() 
        {
            var typeWithAttributes = typeof(SocialAPIAttribute);
            var apis = Assembly
                .GetAssembly(typeWithAttributes)
                .GetTypes()
                .Where(type => type.CustomAttributes.Any(attribute => attribute.AttributeType == typeWithAttributes))
                .Select(x => new SocialAPIViewModel()
                {
                    Name = x.Name,
                    Methods = x.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Select(method => new SocialAPIMethodViewModel()
                    {
                        Name = method.Name,
                        Parametres = method.GetParameters().Select(par => new SocialParameterViewModel()
                        {
                            Name = par.Name,
                            Type = par.ParameterType.Name

                        }).ToList()
                    })
                }).ToList();

            return View(apis);
        }
        
    }
}
