using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;

namespace Net14.Web.EfStuff
{
    public static class ExtentionSeed
    {
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                SeedProduct(scope);

                SeedUser(scope);
                SeedPostAndComm(scope);
                GroupSeed(scope);

                SeedImages(scope);
            }

            return host;
        }

        private static void SeedImages(IServiceScope scope)
        {
            var imageRepository = scope.ServiceProvider.GetService<ImageRepository>();

            if (imageRepository.Any())
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                var image = new Image
                {
                    Name = $"Girl {i}",
                    Url = $"/images/gallery/girl{i}.png"
                };

                imageRepository.Save(image);
            }
        }

        private static void SeedProduct(IServiceScope scope)
        {
            var productRepository = scope.ServiceProvider.GetService<ProductRepository>();
            var sizeRepository = scope.ServiceProvider.GetService<SizeRepository>();

            if (!productRepository.Any())
            {
                if (!sizeRepository.Any())
                {
                    var size = new List<Size>()
                {
                    new Size(){Name="35"},
                    new Size(){Name="35.5"},
                    new Size(){Name="36"},
                    new Size(){Name="36.5"},
                    new Size(){Name="37"},
                    new Size(){Name="37.5"},
                    new Size(){Name="38"},
                    new Size(){Name="38.5"},
                    new Size(){Name="39"},
                    new Size(){Name="39.5"},
                    new Size(){Name="40"},
                    new Size(){Name="40.5"},
                    new Size(){Name="41"},
                    new Size(){Name="41.5"},
                    new Size(){Name="42"},
                    new Size(){Name="42.5"},
                    new Size(){Name="43"},
                    new Size(){Name="43.5"},
                    new Size(){Name="44"},
                    new Size(){Name="44.5"},
                    new Size(){Name="45"},
                    new Size(){Name="S"},
                    new Size(){Name="M"},
                    new Size(){Name="L"},
                    new Size(){Name="35-37"},
                    new Size(){Name="38-41"},
                    new Size(){Name="42-45"},
                };
                    sizeRepository.SaveList(size);
                }

                var size35 = sizeRepository.GetByName("35");
                var size35_5 = sizeRepository.GetByName("35.5");
                var size36 = sizeRepository.GetByName("36");
                var size36_5 = sizeRepository.GetByName("36.5");
                var size37 = sizeRepository.GetByName("37");
                var size37_5 = sizeRepository.GetByName("37.5");
                var size38 = sizeRepository.GetByName("38");
                var size38_5 = sizeRepository.GetByName("38.5");
                var size39 = sizeRepository.GetByName("39");
                var size39_5 = sizeRepository.GetByName("39");
                var size40 = sizeRepository.GetByName("40");
                var size40_5 = sizeRepository.GetByName("40.5");
                var size41 = sizeRepository.GetByName("41");
                var size41_5 = sizeRepository.GetByName("41.5");
                var size42 = sizeRepository.GetByName("42");
                var size42_5 = sizeRepository.GetByName("42.5");
                var size43 = sizeRepository.GetByName("43");
                var size43_5 = sizeRepository.GetByName("43.5");
                var size44 = sizeRepository.GetByName("44");
                var size44_5 = sizeRepository.GetByName("44.5");
                var size45 = sizeRepository.GetByName("45");
                var sizeS = sizeRepository.GetByName("S");
                var sizeM = sizeRepository.GetByName("M");
                var sizeL = sizeRepository.GetByName("L");
                var size35_37 = sizeRepository.GetByName("35-37");
                var size38_41 = sizeRepository.GetByName("38-41");
                var size42_45 = sizeRepository.GetByName("42-45");


                var product1 = new Product()
                {

                    Name = "Air Force 1 ’07 W White/Black",
                    Quantity = 1,
                    Price = 120,
                    BrandCategories = EnumStore.BrandСategories.Nike,
                    CoolCategories = EnumStore.CoolCategories.Snekers,
                    CoolColors = EnumStore.CoolColors.White,
                    CoolMaterial = EnumStore.CoolMaterial.Leather,
                    Gender = EnumStore.Gender.Women,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url ="/images/Store/14-1.jpg",Odrer=1},
                        new StoreImage() { Url ="/images/Store/14-2.jpg",Odrer=2},
                        new StoreImage() { Url ="/images/Store/14-3.jpg",Odrer=3},
                        new StoreImage() { Url ="/images/Store/14-4.jpg",Odrer=4}
                    },
                    Sizes= new List<Size>(){size35,size35_5,size36,size36_5,size37,size37_5,size38}
                };

                var product2 = new Product()
                {
                    Name = "Air Force 1 LV8 W White",
                    Quantity = 3,
                    Price = 133,
                    BrandCategories = EnumStore.BrandСategories.Nike,
                    CoolCategories = EnumStore.CoolCategories.Snekers,
                    CoolColors = EnumStore.CoolColors.White,
                    CoolMaterial = EnumStore.CoolMaterial.Leather,
                    Gender = EnumStore.Gender.Women,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url ="/images/Store/16-1.jpg",Odrer=1},
                        new StoreImage() { Url ="/images/Store/16-2.jpg",Odrer=2},
                        new StoreImage() { Url ="/images/Store/16-3.jpg",Odrer=3},
                        new StoreImage() { Url ="/images/Store/16-4.jpg",Odrer=4}
                    },
                    Sizes = new List<Size>() { size35, size35_5, size36, size36_5, size37, size37_5, size39 }
                };
                var product3 = new Product()
                {
                    Name = "Air Force 1 LV8 1 HO20 W",
                    Quantity = 3,
                    Price = 170,
                    BrandCategories = EnumStore.BrandСategories.Nike,
                    CoolCategories = EnumStore.CoolCategories.Snekers,
                    CoolColors = EnumStore.CoolColors.White,
                    CoolMaterial = EnumStore.CoolMaterial.Leather,
                    Gender = EnumStore.Gender.Women,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url ="/images/Store/17-1.jpg",Odrer=1},
                        new StoreImage() { Url ="/images/Store/17-2.jpg",Odrer=2},
                        new StoreImage() { Url ="/images/Store/17-3.jpg",Odrer=3},
                        new StoreImage() { Url ="/images/Store/17-4.jpg",Odrer=4}
                    },
                    Sizes = new List<Size>() { size35, size35_5, size36_5, size38_5, size39, size39_5 }
                };
                var product4 = new Product()
                {
                    Name = "Air Max 270 React W Grey",
                    Quantity = 1,
                    Price = 110,
                    BrandCategories = EnumStore.BrandСategories.Nike,
                    CoolCategories = EnumStore.CoolCategories.Snekers,
                    CoolColors = EnumStore.CoolColors.White,
                    CoolMaterial = EnumStore.CoolMaterial.Textile,
                    Gender = EnumStore.Gender.Women,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url ="/images/Store/18-1.jpg",Odrer=1},
                        new StoreImage() { Url ="/images/Store/18-2.jpg",Odrer=2},
                        new StoreImage() { Url ="/images/Store/18-3.jpg",Odrer=3},
                        new StoreImage() { Url ="/images/Store/18-4.jpg",Odrer=4}
                    },
                    Sizes = new List<Size>() { size35, size35_5, size36_5, size38_5, size39, size40 }
                };
                var product5 = new Product()
                {
                    Name = "Originals Supercourt 2 White",
                    Quantity = 1,
                    Price = 115,
                    BrandCategories = EnumStore.BrandСategories.Adidas,
                    CoolCategories = EnumStore.CoolCategories.Snekers,
                    CoolColors = EnumStore.CoolColors.White,
                    CoolMaterial = EnumStore.CoolMaterial.Leather,
                    Gender = EnumStore.Gender.Men,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url = "/images/Store/15-1.jpg",Odrer=1 },
                        new StoreImage() { Url = "/images/Store/15-2.jpg",Odrer=2 },
                        new StoreImage() { Url = "/images/Store/15-3.jpg",Odrer=3 },
                        new StoreImage() { Url = "/images/Store/15-4.jpg",Odrer=4 }
                    },
                    Sizes = new List<Size>() { size40, size40_5, size41, size41_5, size42, size43 }
                };
                var product6 = new Product()
                {
                    Name = "Gel-Lyte III RE Grey",
                    Quantity = 3,
                    Price = 170,
                    BrandCategories = EnumStore.BrandСategories.Asics,
                    CoolCategories = EnumStore.CoolCategories.Snekers,
                    CoolColors = EnumStore.CoolColors.Gray,
                    CoolMaterial = EnumStore.CoolMaterial.Suede,
                    Gender = EnumStore.Gender.Men,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url = "/images/Store/21-1.jpg",Odrer=1 },
                        new StoreImage() { Url = "/images/Store/21-2.jpg",Odrer=2 },
                        new StoreImage() { Url = "/images/Store/21-3.jpg",Odrer=3 },
                        new StoreImage() { Url = "/images/Store/21-4.jpg",Odrer=4 }
                    },
                    Sizes = new List<Size>() { size40, size40_5, size41, size42_5, size42, size43_5 }
                };
                var product7 = new Product()
                {
                    Name = "Originals Niteball Black",
                    Quantity = 2,
                    Price = 188,
                    BrandCategories = EnumStore.BrandСategories.Adidas,
                    CoolCategories = EnumStore.CoolCategories.Snekers,
                    CoolColors = EnumStore.CoolColors.Black,
                    CoolMaterial = EnumStore.CoolMaterial.Textile,
                    Gender = EnumStore.Gender.Men,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url = "/images/Store/19-1.jpg",Odrer=1 },
                        new StoreImage() { Url = "/images/Store/19-2.jpg",Odrer=2 },
                        new StoreImage() { Url = "/images/Store/19-3.jpg",Odrer=3 },
                        new StoreImage() { Url = "/images/Store/19-4.jpg",Odrer=4 }
                    },
                    Sizes = new List<Size>() { size40, size40_5, size41, size42_5, size42, size43_5 }
                };
                var product8 = new Product()
                {
                    Name = "Shadow 5000 Yellow",
                    Quantity = 2,
                    Price = 110,
                    BrandCategories = EnumStore.BrandСategories.Saucony,
                    CoolCategories = EnumStore.CoolCategories.Snekers,
                    CoolColors = EnumStore.CoolColors.Yellow,
                    CoolMaterial = EnumStore.CoolMaterial.Suede,
                    Gender = EnumStore.Gender.Men,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url = "/images/Store/20-1.jpg",Odrer=1 },
                        new StoreImage() { Url = "/images/Store/20-2.jpg",Odrer=2 },
                        new StoreImage() { Url = "/images/Store/20-3.jpg",Odrer=3 },
                        new StoreImage() { Url = "/images/Store/20-4.jpg",Odrer=4}
                    },
                    Sizes = new List<Size>() { size40, size41, size42_5, size42, size43_5,size45 }

                };
                var product9 = new Product()
                {
                    Name = "Club C 85 Revenge Burgundy",
                    Quantity = 5,
                    Price = 100,
                    BrandCategories = EnumStore.BrandСategories.Reebok,
                    CoolCategories = EnumStore.CoolCategories.Gumshoes,
                    CoolColors = EnumStore.CoolColors.Red,
                    CoolMaterial = EnumStore.CoolMaterial.Leather,
                    Gender = EnumStore.Gender.Men,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url = "/images/Store/22-1.jpg",Odrer=1},
                        new StoreImage() { Url = "/images/Store/22-2.jpg",Odrer=2},
                        new StoreImage() { Url = "/images/Store/22-3.jpg",Odrer=3},
                        new StoreImage() { Url = "/images/Store/22-4.jpg",Odrer=4}
                    },
                    Sizes = new List<Size>() { size40, size40_5, size41, size42_5, size42, size44_5,size44 }
                };
                var product10 = new Product()
                {
                    Name = "Gel-Kayano 28 Lake Drive",
                    Quantity = 5,
                    Price = 200,
                    BrandCategories = EnumStore.BrandСategories.Asics,
                    CoolCategories = EnumStore.CoolCategories.Run,
                    CoolColors = EnumStore.CoolColors.Blue,
                    CoolMaterial = EnumStore.CoolMaterial.Textile,
                    Gender = EnumStore.Gender.Men,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url = "/images/Store/13-1.png",Odrer=1},
                        new StoreImage() { Url = "/images/Store/13-2.png",Odrer=2},
                        new StoreImage() { Url = "/images/Store/13-3.png",Odrer=3},
                       
                    },
                    Sizes = new List<Size>() { size40, size40_5, size41, size42_5, size42, size44_5, size44 }
                };
                var product11 = new Product()
                {
                    Name = "Gel-Nimbus 24",
                    Quantity = 7,
                    Price = 175,
                    BrandCategories = EnumStore.BrandСategories.Asics,
                    CoolCategories = EnumStore.CoolCategories.Run,
                    CoolColors = EnumStore.CoolColors.Orange,
                    CoolMaterial = EnumStore.CoolMaterial.Textile,
                    Gender = EnumStore.Gender.Men,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url = "/images/Store/12-1.jpg",Odrer=1},
                        new StoreImage() { Url = "/images/Store/12-2.jpg",Odrer=2},
                        new StoreImage() { Url = "/images/Store/12-3.jpg",Odrer=3},
                        new StoreImage() { Url = "/images/Store/12-4.jpg",Odrer=4}
                    },
                    Sizes = new List<Size>() { size40, size40_5, size41, size42_5, size42, size44_5, size44 }
                };
                var product12 = new Product()
                {
                    Name = "Everyday Cushioned Crew Black",
                    Quantity = 5,
                    Price = 5,
                    BrandCategories = EnumStore.BrandСategories.Nike,
                    CoolCategories = EnumStore.CoolCategories.Accessories,
                    CoolColors = EnumStore.CoolColors.Black,
                    CoolMaterial = EnumStore.CoolMaterial.Textile,
                    Gender = EnumStore.Gender.Unisex,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url = "/images/Store/1-1.jpg",Odrer=1},
                    },
                    Sizes = new List<Size>() { size35_37,size38_41 }
                };
                var product13 = new Product()
                {
                    Name = "Everyday Cushioned Crew White",
                    Quantity = 3,
                    Price = 5,
                    BrandCategories = EnumStore.BrandСategories.Nike,
                    CoolCategories = EnumStore.CoolCategories.Accessories,
                    CoolColors = EnumStore.CoolColors.White,
                    CoolMaterial = EnumStore.CoolMaterial.Textile,
                    Gender = EnumStore.Gender.Unisex,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url = "/images/Store/2-1.jpg",Odrer=1},
                    },
                    Sizes = new List<Size>() {size38_41,size42_45 }
                };
                var product14 = new Product()
                {
                    Name = "Originals Solid Crew Black",
                    Quantity = 12,
                    Price = 5,
                    BrandCategories = EnumStore.BrandСategories.Adidas,
                    CoolCategories = EnumStore.CoolCategories.Accessories,
                    CoolColors = EnumStore.CoolColors.Black,
                    CoolMaterial = EnumStore.CoolMaterial.Textile,
                    Gender = EnumStore.Gender.Unisex,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url = "/images/Store/3-1.jpg",Odrer=1},
                    },
                    Sizes = new List<Size>() { size38_41, size42_45 }
                };
                var product15 = new Product()
                {
                    Name = "Originals Solid Crew White",
                    Quantity = 12,
                    Price = 5,
                    BrandCategories = EnumStore.BrandСategories.Adidas,
                    CoolCategories = EnumStore.CoolCategories.Accessories,
                    CoolColors = EnumStore.CoolColors.White,
                    CoolMaterial = EnumStore.CoolMaterial.Textile,
                    Gender = EnumStore.Gender.Unisex,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url = "/images/Store/4-1.jpg",Odrer=1},
                    },
                    Sizes = new List<Size>() { size35_37, size42_45 }
                };
                var product16 = new Product()
                {
                    Name = "S Backpack Grey",
                    Quantity = 5,
                    Price = 35,
                    BrandCategories = EnumStore.BrandСategories.Puma,
                    CoolCategories = EnumStore.CoolCategories.Bags,
                    CoolColors = EnumStore.CoolColors.Gray,
                    CoolMaterial = EnumStore.CoolMaterial.Textile,
                    Gender = EnumStore.Gender.Unisex,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url = "/images/Store/5-1.jpg",Odrer=1},
                        new StoreImage() { Url = "/images/Store/5-2.jpg",Odrer=2},
                        new StoreImage() { Url = "/images/Store/5-3.jpg",Odrer=3},
                        new StoreImage() { Url = "/images/Store/5-4.jpg",Odrer=4}
                    },
                    Sizes = new List<Size>() { sizeM, sizeL }
                };
                var product17 = new Product()
                {
                    Name = "Sportswear Essentials Green",
                    Quantity = 5,
                    Price = 70,
                    BrandCategories = EnumStore.BrandСategories.Nike,
                    CoolCategories = EnumStore.CoolCategories.Bags,
                    CoolColors = EnumStore.CoolColors.Green,
                    CoolMaterial = EnumStore.CoolMaterial.Textile,
                    Gender = EnumStore.Gender.Unisex,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Url = "/images/Store/6-1.jpg",Odrer=1},
                        new StoreImage() { Url = "/images/Store/6-2.jpg",Odrer=2},
                        new StoreImage() { Url = "/images/Store/6-3.jpg",Odrer=3},
                        new StoreImage() { Url = "/images/Store/6-4.jpg",Odrer=4}
                    },
                    Sizes = new List<Size>() { sizeM, sizeL }
                };


                productRepository.Save(product1);
                productRepository.Save(product2);
                productRepository.Save(product3);
                productRepository.Save(product4);
                productRepository.Save(product5);
                productRepository.Save(product6);
                productRepository.Save(product7);
                productRepository.Save(product8);
                productRepository.Save(product9);
                productRepository.Save(product10);
                productRepository.Save(product11);
                productRepository.Save(product12);
                productRepository.Save(product13);
                productRepository.Save(product14);
                productRepository.Save(product15);
                productRepository.Save(product16);
                productRepository.Save(product17);
            };


        }
        private static void SeedUser(IServiceScope scope) 
        {
            var userRepository = scope.ServiceProvider.GetService<SocialUserRepository>();
            if (!userRepository.Any()) 
            {
                var user0 = new UserSocial()
                {
                    FirstName = "admin",
                    LastName = "admin",
                    Age = 7,
                    City = "Grodno",
                    Country = "Russia",
                    Email = "admin",
                    Password = "admin",
                    UserPhoto = "/images/Social/image-user/pavel.jpg",
                    Role = SiteRole.Admin
                };
                userRepository.Save(user0);

                var user = new UserSocial()
                {
                    FirstName = "Aleksey",
                    LastName = "Guravlev",
                    Age = 20,
                    City = "Minsk",
                    Country = "Belarus",
                    Email = "email",
                    Password = "pass",
                    UserPhoto = "/images/Social/image-user/guravl.jpg"
                };

                var message = new SocialMessages()
                {
                    Sender = user0,
                    Reciever = user,
                    Text = "Hello!",
                    Date = DateTime.Now
                };

                user.RecievedMessages.Add(message);
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
                    UserPhoto = "/images/Social/image-user/perepech.jpg"
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
                    UserPhoto = "/images/Social/image-user/shchur.jpg"
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
                    TypePost = "no",
                    Comments = new List<SocialComment>()
                };

                var like = new SocialLike()
                {
                    Post = post,
                    User = commentUser
                };

                post.Likes.Add(like);

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
                var user = userRepository.GetByEmAndPass("email2", "pass2");
                var groupPost = new PostSocial()
                {
                    CommentOfUser = "Good car",
                    Comments = new List<SocialComment>(),
                    ImageUrl = "/images/Social/bmw.jpg",
                    TypePost = "no",
                    User = user
                };

                var like = new SocialLike()
                {
                    Post = groupPost,
                    User = user
                };

                groupPost.Likes.Add(like);

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
                    Posts = new List<PostSocial>(),
                    Tags = new List<GroupTags>()

                };

                var tag1 = new GroupTags() { Group = group, Tag = "#cars" };
                var tag2 = new GroupTags() { Group = group, Tag = "#bmw" };
                group.Tags.Add(tag1);
                group.Tags.Add(tag2);

                group.Posts.Add(groupPost);
                groupRepository.Save(group);


                var group2 = new GroupSocial()
                {
                    Description = "Moto",
                    Members = userRepository.GetAll().Where(user => user.FirstName == "Kiril").ToList(),
                    Name = "Moto Club",
                    PhotoUrl = "/images/Social/moto.jpeg",
                    Posts = new List<PostSocial>(),
                    Tags = new List<GroupTags>()

                };

                var tag3 = new GroupTags() { Group = group, Tag = "#moto" };
                var tag4 = new GroupTags() { Group = group, Tag = "#bike" };

                group2.Tags.Add(tag3);
                group2.Tags.Add(tag4);


                groupRepository.Save(group2);
            }
        }
    }
}

