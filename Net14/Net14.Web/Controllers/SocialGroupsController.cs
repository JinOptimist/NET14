using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models;
using Net14.Web.EfStuff.DbModel.SocialDbModels;

namespace Net14.Web.Controllers
{
    public class SocialGroupsController : Controller
    {
        private SocialGroupRepository _socialGroupRepository;
        public SocialGroupsController(SocialGroupRepository socialGroupRepository) 
        {
            _socialGroupRepository = socialGroupRepository;
        }
        public IActionResult GetGroups()
        {
            var model = _socialGroupRepository.GetAll()
                .Select(group => new SocialGroupViewModel()
                {
                    Name = group.Name,
                    PhotoUrl = group.PhotoUrl,
                    Id = group.Id
                }).ToList();

            return View(model);
        }

        public IActionResult GetSingleGroup(int id) 
        {
            var group = _socialGroupRepository.Get(id);
            var model = new SocialGroupViewModel()
            {
                Description = group.Description,
                Members = group.Members.Select(user =>
                    new SocialUserViewModel()
                    {
                        Age = user.Age,
                        City = user.City,
                        Country = user.Country,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        Id = user.Id,
                        LastName = user.LastName,
                        UserPhoto = user.UserPhoto
                    }).ToList(),
                Name = group.Name,
                PhotoUrl = group.PhotoUrl,
                Posts = group.Posts.Select(post =>
                new SocialPostViewModel()
                {
                    Comments = post.Comments.Select(post =>
                        new SocialCommentViewModel()
                        {
                            DateOfPosting = post.DateOfPosting,
                            Text = post.Text,
                            User = new SocialUserViewModel()
                            {
                                UserPhoto = post.User.UserPhoto,
                                Age = post.User.Age,
                                City = post.User.City,
                                Country = post.User.Country,
                                Email = post.User.Email,
                                FirstName = post.User.FirstName,
                                Id = post.User.Id,
                                LastName = post.User.LastName,
                            }
                        }).ToList(),
                    CommentsOfOwner = post.CommentOfUser,
                    Id = post.Id,
                    ImageUrl = post.ImageUrl,
                    Likes = post.Likes,
                    NameOfUser = post.User.LastName,
                    TypePost = post.TypePost,
                    UserId  = post.User.Id,
                    UserPhotoUrl = post.User.UserPhoto

                        
                }).ToList()
            };

            return View(model);
        }
    }
}
