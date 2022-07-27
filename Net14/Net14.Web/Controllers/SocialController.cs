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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Net14.Web.Models.SocialModels.Enums;

namespace Net14.Web.Controllers
{
    public class SocialController : Controller

    {
        private SocialUserRepository _socialUserRepository;
        private SocialPostRepository _socialPostRepository;
        private UserService _userService;
        private IMapper _mapper;
        private RecomendationsService _recomendationsService;
        private IWebHostEnvironment _webHostEnvironment;
        private ComplainsSocialRepository _complainsSocialRepository;


        public SocialController(SocialUserRepository socialUserRepository,
            SocialPostRepository socialPostRepository,
            UserService userService, IMapper mapper,
            RecomendationsService recomendationsService,
            IWebHostEnvironment webHostEnvironment,
            ComplainsSocialRepository complainsSocialRepository
            )
        {
            _socialPostRepository = socialPostRepository;
            _socialUserRepository = socialUserRepository;
            _userService = userService;
            _mapper = mapper;
            _recomendationsService = recomendationsService;
            _webHostEnvironment = webHostEnvironment;
            _complainsSocialRepository = complainsSocialRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            var topThree = _mapper.Map<List<SocialPostViewModel>>(_recomendationsService.GetIndexRecomendations());
            var posts = _socialPostRepository.GetAll()
                .OrderByDescending(post => post.Likes.Count)
                .ThenByDescending(post => post.DateOfPosting);

            var viewPost = _mapper.Map<List<SocialPostViewModel>>(posts);


            if (_userService.GetCurrent() != null)

            {
                var currentUser = _userService.GetCurrent();
                viewPost.ForEach(x =>
                {
                    if (posts.Single(dbPost => dbPost.Id == x.Id).Likes.Any(like => like.User.Id == currentUser.Id))
                    {
                        x.IsLikedCurrentUser = true;
                    }
                    if (x.UserId == currentUser.Id)
                    {
                        x.IsByCurrentUser = true;
                    }
                    if (posts.Single(dbPost => dbPost.Id == x.Id).Complains.Any(comp => comp.OwnerOfComplain.Id == currentUser.Id)) 
                    {
                        x.IsBlockedByUser = true;
                    }
                });

            }
            var finalModel = new SocialPostWithTopViewModel()
            {
                Posts = viewPost,
                TopThreePost = topThree
            };


            return View(finalModel);
        }

        [HttpPost]
        public IActionResult Index(SocialAddPostViewModel postViewModel)
        {
            var user = _userService.GetCurrent();

            var post = new PostSocial()
            {
                User = user,
                CommentOfUser = postViewModel.CommentOfUser,
            };

            _socialPostRepository.Save(post);

            var extension = Path.GetExtension(postViewModel.ImageUrl.FileName);
            var fileName = $"post{post.Id}{extension}";
            var path = Path.Combine(
                _webHostEnvironment.WebRootPath,
                "images",
                "Social",
                fileName);

            using (var fs = new FileStream(path, FileMode.CreateNew))
            {
                postViewModel.ImageUrl.CopyTo(fs);
            }

            post.ImageUrl = $"/images/Social/{fileName}";

            _socialPostRepository.Save(post);

            var photo = new SocialPhoto()
            {
                Owner = user,
                Url = post.ImageUrl
            };

            _socialUserRepository.AddPhoto(photo, user.Id);


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


        public IActionResult ShowProfile(int userId)
        {
            var user = _socialUserRepository.Get(userId);
            var dbUsersPosts = user.Posts
                .OrderByDescending(post => post.Likes.Count)
                .ThenBy(post => post.DateOfPosting);

            var postUser = _mapper.Map<List<SocialPostViewModel>>(dbUsersPosts);
            var model = _mapper.Map<SocialProfileViewModel>(user);
            model.UserPost = postUser;
            model.UserFriendsCount = user.Friends.Count;
            model.UserGroupsCount = user.Groups.Count;
            model.UserPhotos = _mapper.Map<List<SocialPhotoViewModel>>(user.Photos);




            if (User.Identity.IsAuthenticated)
            {
                var currentUser = _userService.GetCurrent();

                model.UserPost.ForEach(x =>
                {
                    if (dbUsersPosts.Single(dbPost => dbPost.Id == x.Id).Likes.Any(like => like.User.Id == currentUser.Id))
                    {
                        x.IsLikedCurrentUser = true;
                    }
                });

                model.IsRequested = currentUser.FriendRequestSent.Any(x => x.Receiver.Id == userId) ? true : false;
                model.IsFriend = currentUser.Friends.Any(x => x.Id == user.Id) ? true : false;

            }


            return View(model);
        }

        [Authorize]
        public IActionResult MyProfile()
        {
            var currentUser = _userService.GetCurrent();
            var dbUsersPosts = currentUser.Posts
                .OrderByDescending(post => post.Likes.Count)
                .ThenByDescending(post => post.DateOfPosting);

            var postUser = _mapper.Map<List<SocialPostViewModel>>(currentUser.Posts);
            var model = _mapper.Map<SocialProfileViewModel>(currentUser);
            postUser.ForEach(x =>
            {
                x.IsByCurrentUser = true;
                if (dbUsersPosts.Single(dbPost => dbPost.Id == x.Id).Likes.Any(like => like.User.Id == currentUser.Id))
                {
                    x.IsLikedCurrentUser = true;
                }
            });

            model.UserPost = postUser;
            model.UserFriendsCount = currentUser.Friends.Count;
            model.UserGroupsCount = currentUser.Groups.Count;
            model.UserPhotos = _mapper.Map<List<SocialPhotoViewModel>>(currentUser.Photos);



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
        public IActionResult ChangeLanguageToEnglish()
        {
            var currentUser = _userService.GetCurrent();
            currentUser.Language = Language.Eng;
            _socialUserRepository.Save(currentUser);

            return RedirectToAction("Index");
        }
        public IActionResult ChangeLanguageToRussian()
        {
            var currentUser = _userService.GetCurrent();
            currentUser.Language = Language.Rus;
            _socialUserRepository.Save(currentUser);

            return RedirectToAction("Index");
        }

        [Authorize]
        [HasRole(SiteRole.Admin)]
        public IActionResult GetComplaint() 
        {
            var posts = _socialPostRepository.GetPostsWithComplains()
                .OrderByDescending(post => post.Complains.Count);
            var complainsPostsViewModels = _mapper.Map<List<SocialPostViewModel>>(posts);
            return View(complainsPostsViewModels);
        }


        public IActionResult ShowAllUsersForAdmin(string sortFieldName = "Id")
        {
            var users = _socialUserRepository.GetAllAndSortedV2(sortFieldName);
            var viewModels = _mapper
                .Map<List<SocialUserRecomendationViewModel>>(users);
            return View(viewModels);
        }
    }
}
