using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.Repositories;
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
                SeedProduct(scope);

            }

            return host;
        }
        private static void SeedProduct(IServiceScope scope)
        {
            var productRepository = scope.ServiceProvider.GetService<ProductRepository>();
            var sizeRepository = scope.ServiceProvider.GetService<SizeRepository>();

            if (!productRepository.Any())
            {
                //var size = new List<Size>()
                //{
                //    new Size(){Name="35"},
                //    new Size(){Name="35.5"},
                //    new Size(){Name="36"},
                //    new Size(){Name="36.5"},
                //    new Size(){Name="37"},
                //    new Size(){Name="37.5"},
                //    new Size(){Name="38"},
                //    new Size(){Name="38.5"},
                //    new Size(){Name="39"},
                //    new Size(){Name="39.5"},
                //    new Size(){Name="40"},
                //    new Size(){Name="40.5"},
                //    new Size(){Name="41"},
                //    new Size(){Name="41.5"},
                //    new Size(){Name="42"},
                //    new Size(){Name="42.5"},
                //    new Size(){Name="43"},
                //    new Size(){Name="43.5"},
                //    new Size(){Name="44"},
                //    new Size(){Name="44.5"},
                //    new Size(){Name="45"},
                //};
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
                        new StoreImage() { Name ="/images/Store/14-1.jpg",Odrer=1},
                        new StoreImage() { Name ="/images/Store/14-2.jpg",Odrer=2},
                        new StoreImage() { Name ="/images/Store/14-3.jpg",Odrer=3},
                        new StoreImage() { Name ="/images/Store/14-4.jpg",Odrer=4}
                    },
                    
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
                        new StoreImage() { Name ="/images/Store/16-1.jpg",Odrer=1},
                        new StoreImage() { Name ="/images/Store/16-2.jpg",Odrer=2},
                        new StoreImage() { Name ="/images/Store/16-3.jpg",Odrer=3},
                        new StoreImage() { Name ="/images/Store/16-4.jpg",Odrer=4}
                    }
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
                        new StoreImage() { Name ="/images/Store/17-1.jpg",Odrer=1},
                        new StoreImage() { Name ="/images/Store/17-2.jpg",Odrer=2},
                        new StoreImage() { Name ="/images/Store/17-3.jpg",Odrer=3},
                        new StoreImage() { Name ="/images/Store/17-4.jpg",Odrer=4}
                    }
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
                        new StoreImage() { Name ="/images/Store/18-1.jpg",Odrer=1},
                        new StoreImage() { Name ="/images/Store/18-2.jpg",Odrer=2},
                        new StoreImage() { Name ="/images/Store/18-3.jpg",Odrer=3},
                        new StoreImage() { Name ="/images/Store/18-4.jpg",Odrer=4}
                    },
                    Sizes = new List<Size>()
                    {

                    }
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
                        new StoreImage() { Name = "/images/Store/15-1.jpg",Odrer=1},
                        new StoreImage() { Name = "/images/Store/15-2.jpg",Odrer=2},
                        new StoreImage() { Name = "/images/Store/15-3.jpg",Odrer=3},
                        new StoreImage() { Name = "/images/Store/15-4.jpg",Odrer=4}
                    }
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
                        new StoreImage() { Name = "/images/Store/21-1.jpg",Odrer=1 },
                        new StoreImage() { Name = "/images/Store/21-2.jpg",Odrer=2 },
                        new StoreImage() { Name = "/images/Store/21-3.jpg",Odrer=3 },
                        new StoreImage() { Name = "/images/Store/21-4.jpg",Odrer=4 }
                    }
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
                        new StoreImage() { Name = "/images/Store/19-1.jpg",Odrer=1 },
                        new StoreImage() { Name = "/images/Store/19-2.jpg",Odrer=2 },
                        new StoreImage() { Name = "/images/Store/19-3.jpg",Odrer=3 },
                        new StoreImage() { Name = "/images/Store/19-4.jpg",Odrer=4 }
                    }
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
                        new StoreImage() { Name = "/images/Store/20-1.jpg",Odrer=1 },
                        new StoreImage() { Name = "/images/Store/20-2.jpg",Odrer=2 },
                        new StoreImage() { Name = "/images/Store/20-3.jpg",Odrer=3 },
                        new StoreImage() { Name = "/images/Store/20-4.jpg",Odrer=4}
                    }

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
                        new StoreImage() { Name = "/images/Store/22-1.jpg",Odrer=1},
                        new StoreImage() { Name = "/images/Store/22-2.jpg",Odrer=2},
                        new StoreImage() { Name = "/images/Store/22-3.jpg",Odrer=3},
                        new StoreImage() { Name = "/images/Store/22-4.jpg",Odrer=4}
                    }
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
            };


        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.Repositories;

namespace Net14.Web.EfStuff
{
    public static class ExtentionSeed
    {
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {

                SeedImage(scope);
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
    }
}
