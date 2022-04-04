using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Net14.Web.EfStuff
{
    public static class ExtentionSeed
    {
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {

                SeedImage(scope);
                SeedUser(scope);
                SeedPostAndComm(scope);
                GroupSeed(scope);
            }

            return host;
        }

        private static void SeedImage(IServiceScope scope)
        {
            var imageRepository = scope.ServiceProvider.GetService<ImageRepository>();

            if (!imageRepository.Any())
            {
                var image = new Image()
                {
                    Name = "qwe",
                    Url = "qwe",
                    Rate = 99
                };

                imageRepository.Save(image);
            }
        }
        private static void SeedUser(IServiceScope scope) 
        {
            var userRepository = scope.ServiceProvider.GetService<SocialUserRepository>();
            if (!userRepository.Any()) 
            {
                var user = new UserSocial()
                {
                    FirstName = "Aleksey",
                    LastName = "Guravlev",
                    Age = 20,
                    City = "Minsk",
                    Country = "Belarus",
                    Email = "email",
                    Password = "pass",
                    UserPhoto = "/images/Social/User.jpg"
                };
                userRepository.Save(user);

                var user2 = new UserSocial()
                {
                    FirstName = "Kiril",
                    LastName = "Perepechkin",
                    Age = 22,
                    City = "Vitebsk",
                    Country = "Belarus",
                    Email = "email2",
                    Password = "pass2",
                    UserPhoto = "/images/Social/User.jpg"
                };
                userRepository.Save(user2);

                var user3 = new UserSocial()
                {
                    FirstName = "Vasily",
                    LastName = "Shchur",
                    Age = 35,
                    City = "Grodno",
                    Country = "Russia",
                    Email = "email3",
                    Password = "pass3",
                    UserPhoto = "/images/Social/User.jpg"
                };
                userRepository.Save(user3);
            }
        }

        private static void SeedPostAndComm(IServiceScope scope) 
        {
            var postRepository = scope.ServiceProvider.GetService<SocialPostRepository>();
            var userRepository = scope.ServiceProvider.GetService<SocialUserRepository>();
            var commentRepository = scope.ServiceProvider.GetService<SocialCommentRepository>();

            var commentUser = userRepository.GetByEmAndPass("email3", "pass3");

            if (!postRepository.Any())
            {

                var post = new PostSocial()
                {
                    User = commentUser,
                    CommentOfUser = "Comment",
                    DateOfPosting = new DateTime(),
                    ImageUrl = "https://www.imgonline.com.ua/examples/bee-on-daisy.jpg",
                    Likes = 20,
                    TypePost = "no",
                    Comments = new List<SocialComment>()
                };

                var comment = new SocialComment()
                {
                    DateOfPosting = DateTime.Now,
                    Post = post,
                    Text = "This is test comment. Try to add your.",
                    User = commentUser
                };

                post.Comments.Add(comment);
                postRepository.Save(post);
                commentRepository.Save(comment);
            }
        }

        private static void GroupSeed(IServiceScope scope) 
        {
            var groupRepository = scope.ServiceProvider.GetService<SocialGroupRepository>();
            var userRepository = scope.ServiceProvider.GetService<SocialUserRepository>();
            var commentRepository = scope.ServiceProvider.GetService<SocialCommentRepository>();
            var postRepository = scope.ServiceProvider.GetService<SocialPostRepository>();


            if (!groupRepository.Any())
            {
                var groupPost = new PostSocial()
                {
                    CommentOfUser = "Good car",
                    Comments = new List<SocialComment>(),
                    ImageUrl = "/images/Social/bmw.jpg",
                    Likes = 10,
                    TypePost = "no",
                    User = userRepository.GetByEmAndPass("email", "pass")
                };

                var groupComment = new SocialComment()
                {
                    Post = groupPost,
                    Text = "I wanna buy",
                    User = userRepository.GetByEmAndPass("email2", "pass2"),
                };

                groupPost.Comments.Add(groupComment);
                postRepository.Save(groupPost);
                commentRepository.Save(groupComment);

                var group = new GroupSocial()
                {
                    Description = "Cars",
                    Members = userRepository.GetAll().Where(user => user.FirstName == "Vasily").ToList(),
                    Name = "BMW Club",
                    PhotoUrl = "/images/Social/bmw.jpg",
                    Posts = new List<PostSocial>()
                };
                group.Posts.Add(groupPost);
                groupRepository.Save(group);
            }
        }
    }
}
