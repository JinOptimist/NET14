using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using AutoMapper;
using Net14.Web.Services;
using Net14.Web.EfStuff;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Net14.Web.Controllers
{
    public class SocialGroupsController : Controller
    {
        private SocialGroupRepository _socialGroupRepository;
        private IMapper _mapper;
        private UserService _userService;
        private SocialPostRepository _socialPostRepository;
        private IWebHostEnvironment _webHostEnvironment;
        public SocialGroupsController(SocialGroupRepository socialGroupRepository, 
            IMapper mapper, UserService userService, SocialPostRepository socialPostRepository,
            IWebHostEnvironment webHostEnvironment) 
        {   
            _mapper = mapper;
            _socialGroupRepository = socialGroupRepository;
            _userService = userService;
            _socialPostRepository = socialPostRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult GetGroups()
        {
            var groupArray = _socialGroupRepository.GetAll();
            var model = _mapper.Map<List<SocialGroupViewModel>>(groupArray);

            
            return View(model);
        }

        [HttpPost]
        public IActionResult GetGroups(string name) 
        {
            var model = _mapper.Map<List<SocialGroupViewModel>>(_socialGroupRepository.GetGroupsByName(name));

            return View(model);
        }

        public IActionResult GetSingleGroup(int id) 
        {
            var group = _socialGroupRepository.Get(id);
            var groupDbPosts = group.Posts;
            var groupViewModel = _mapper.Map<SocialGroupViewModel>(group);

            if (User.Identity.IsAuthenticated) 
            {
                var currentUser = _userService.GetCurrent();

                groupViewModel.Posts.ForEach(x =>
                {
                    if (groupDbPosts.Single(dbPost => dbPost.Id == x.Id).Likes.Any(like => like.User.Id == currentUser.Id))
                    {
                        x.IsLikedCurrentUser = true;
                    }
                });

                if (group.Members.Contains(currentUser))
                {
                    groupViewModel.IsCurUserIsMember = true;
                }
                else
                {
                    groupViewModel.IsCurUserIsMember = false;
                }
            }

            var finalModel = new SocialGroupWithHotViewModel()
            {
                Group = groupViewModel,
                HotPosts = _mapper.Map<List<SocialPostViewModel>>(group.Posts.OrderByDescending(post => post.Likes.Count)
                .ThenByDescending(post => post.DateOfPosting)
                .Take(3).ToList())
            };

            return View(finalModel);
        }

        public IActionResult AddPost(SocialGroupAddPostViewModel postViewModel)
        {
            var user = _userService.GetCurrent();
            var group = _socialGroupRepository.Get(postViewModel.GroupId);

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
            _socialGroupRepository.AddPost(post, group.Id);

            return Redirect($"/SocialGroups/GetSingleGroup?id={postViewModel.GroupId}");
        }
    }
}
