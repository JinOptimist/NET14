using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            Seed(host);

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void Seed(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var webContext = scope.ServiceProvider.GetService<WebContext>();

                if (!webContext.Images.Any())
                {
                    var image = new Image() { 
                        Name = "qwe",
                        Url = "qwe",
                        Rate = 99
                    };

                    webContext.Images.Add(image);
                    webContext.SaveChanges();
                };
                if (!webContext.Users.Any()) 
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
                    var user3 = new UserSocial()
                    {
                        FirstName = "name2",
                        LastName = "lastname2",
                        Age = 35,
                        City = "Grodno",
                        Country = "Rissia",
                        Email = "email3",
                        Password = "pass3",
                        UserPhoto = "/images/Social/User.jpg"
                    };
                    webContext.Users.AddRange(user, user2, user3);
                    webContext.SaveChanges();
                    if (!webContext.Posts.Any())
                    {
                        var post = new PostSocial()
                        {
                            UserId = user.Id,
                            Comments = "Comment",
                            DateOfPosting = new DateTime(),
                            ImageUrl = "https://www.imgonline.com.ua/examples/bee-on-daisy.jpg",
                            Likes = 20,
                            TypePost = "no"
                        };
                        webContext.Posts.Add(post);
                        webContext.SaveChanges();
                    }
                }

            }
        }
    }
}
