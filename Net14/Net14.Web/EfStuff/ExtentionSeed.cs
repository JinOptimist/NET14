using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.Repositories;
using System.Collections.Generic;

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

            //if (!sizeRepository.Any())
            //{
            //    var size = new List<Size>()
            //    {
            //    new Size(){Id=1,Name="35"},
            //    new Size(){Id=2,Name="35.5"},
            //    new Size(){Id=3,Name="36"},
            //    new Size(){Id=4,Name="36.5"},
            //    new Size(){Id=5,Name="37"},
            //    new Size(){Id=6,Name="37.5"},
            //    new Size(){Id=7,Name="38"},
            //    new Size(){Id=8,Name="38.5"},
            //    new Size(){Id=9,Name="39"},
            //    new Size(){Id=10,Name="39.5"},
            //    new Size(){Id=11,Name="40"},
            //    new Size(){Id=12,Name="40.5"},
            //    new Size(){Id=13,Name="41"},
            //    new Size(){Id=14,Name="41.5"},
            //    new Size(){Id=15,Name="42"},
            //    new Size(){Id=16,Name="42.5"},
            //    new Size(){Id=17,Name="43"},
            //    new Size(){Id=18,Name="43.5"},
            //    new Size(){Id=19,Name="44"},
            //    new Size(){Id=20,Name="44.5"},
            //    new Size(){Id=21,Name="45"},
            //    };
            //    //sizeRepository.Save(size);
            //}
             
            if (!productRepository.Any())
            {
                var product1 = new Product()
                {
                    
                    Name = "Air Force 1 ’07 W White/Black",
                    Quantity = 1,
                    Price = 120,
                    BrandCategories = (EnumStore.BrandСategories)1,
                    CoolCategories = (EnumStore.CoolCategories)4,
                    CoolColors = (EnumStore.CoolColors)1,
                    CoolMaterial = (EnumStore.CoolMaterial)1,
                    Gender = (EnumStore.Gender)2,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Name ="/images/Store/11.jpg"},
                        new StoreImage() { Name ="/images/Store/12.jpg"},
                        new StoreImage() { Name ="/images/Store/13.jpg"},
                        new StoreImage() { Name ="/images/Store/14.jpg"}
                    },
                    
                };
                             
                var product2 = new Product()
                {
                    Name = "Air Force 1 LV8 W White",
                    Quantity = 3,
                    Price = 133,
                    BrandCategories = (EnumStore.BrandСategories)1,
                    CoolCategories = (EnumStore.CoolCategories)4,
                    CoolColors = (EnumStore.CoolColors)1,
                    CoolMaterial = (EnumStore.CoolMaterial)1,
                    Gender = (EnumStore.Gender)2,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Name ="/images/Store/16.jpg"},
                        new StoreImage() { Name ="/images/Store/16.1.jpg"},
                        new StoreImage() { Name ="/images/Store/16.2.jpg"},
                        new StoreImage() { Name ="/images/Store/16.3.jpg"}
                    }
                };
                var product3 = new Product()
                {
                    Name = "Air Force 1 LV8 1 HO20 W",
                    Quantity = 3,
                    Price = 170,
                    BrandCategories = (EnumStore.BrandСategories)1,
                    CoolCategories = (EnumStore.CoolCategories)4,
                    CoolColors = (EnumStore.CoolColors)1,
                    CoolMaterial = (EnumStore.CoolMaterial)1,
                    Gender = (EnumStore.Gender)2,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Name ="/images/Store/17.jpg"},
                        new StoreImage() { Name ="/images/Store/17.1.jpg"},
                        new StoreImage() { Name ="/images/Store/17.2.jpg"},
                        new StoreImage() { Name ="/images/Store/17.3.jpg"}
                    }
                };
                var product4 = new Product()
                {
                    Name = "Air Max 270 React W Grey",
                    Quantity = 1,
                    Price = 110,
                    BrandCategories = (EnumStore.BrandСategories)1,
                    CoolCategories = (EnumStore.CoolCategories)4,
                    CoolColors = (EnumStore.CoolColors)1,
                    CoolMaterial = (EnumStore.CoolMaterial)2,
                    Gender = (EnumStore.Gender)2,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Name ="/images/Store/18.jpg"},
                        new StoreImage() { Name ="/images/Store/18.1.jpg"},
                        new StoreImage() { Name ="/images/Store/18.2.jpg"},
                        new StoreImage() { Name ="/images/Store/18.3.jpg"}
                    },
                    Sizes= new List<Size>()
                    {

                    }
                };
                var product5 = new Product()
                {
                    Name = "Originals Supercourt 2 White",
                    Quantity = 1,
                    Price = 115,
                    BrandCategories = (EnumStore.BrandСategories)2,
                    CoolCategories = (EnumStore.CoolCategories)4,
                    CoolColors = (EnumStore.CoolColors)1,
                    CoolMaterial = (EnumStore.CoolMaterial)1,
                    Gender = (EnumStore.Gender)1,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Name = "/images/Store/15.jpg" },
                        new StoreImage() { Name = "/images/Store/15.1.jpg" },
                        new StoreImage() { Name = "/images/Store/15.2.jpg" },
                        new StoreImage() { Name = "/images/Store/15.3.jpg" }
                    }
                };
                var product6 = new Product()
                {
                    Name = "Gel-Lyte III RE Grey",
                    Quantity = 3,
                    Price = 170,
                    BrandCategories = (EnumStore.BrandСategories)4,
                    CoolCategories = (EnumStore.CoolCategories)4,
                    CoolColors = (EnumStore.CoolColors)3,
                    CoolMaterial = (EnumStore.CoolMaterial)4,
                    Gender = (EnumStore.Gender)1,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Name = "/images/Store/21.jpg" },
                        new StoreImage() { Name = "/images/Store/21.1.jpg" },
                        new StoreImage() { Name = "/images/Store/21.2.jpg" },
                        new StoreImage() { Name = "/images/Store/21.3.jpg" }
                    }
                };
                var product7 = new Product()
                {
                    Name = "Originals Niteball Black",
                    Quantity = 2,
                    Price = 188,
                    BrandCategories = (EnumStore.BrandСategories)2,
                    CoolCategories = (EnumStore.CoolCategories)4,
                    CoolColors = (EnumStore.CoolColors)4,
                    CoolMaterial = (EnumStore.CoolMaterial)2,
                    Gender = (EnumStore.Gender)1,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Name = "/images/Store/19.jpg" },
                        new StoreImage() { Name = "/images/Store/19.1.jpg" },
                        new StoreImage() { Name = "/images/Store/19.2.jpg" },
                        new StoreImage() { Name = "/images/Store/19.3.jpg" }
                    }
                };
                var product8 = new Product()
                {
                    Name = "Shadow 5000 Yellow",
                    Quantity = 2,
                    Price = 110,
                    BrandCategories = (EnumStore.BrandСategories)5,
                    CoolCategories = (EnumStore.CoolCategories)4,
                    CoolColors = (EnumStore.CoolColors)6,
                    CoolMaterial = (EnumStore.CoolMaterial)4,
                    Gender = (EnumStore.Gender)1,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Name = "/images/Store/20.jpg" },
                        new StoreImage() { Name = "/images/Store/20.1.jpg" },
                        new StoreImage() { Name = "/images/Store/20.2.jpg" },
                        new StoreImage() { Name = "/images/Store/20.3.jpg" }
                    }

                };
                var product9 = new Product()
                {
                    Id = 9,
                    Name = "Club C 85 Revenge Burgundy",
                    Quantity = 5,
                    Price = 100,
                    BrandCategories = (EnumStore.BrandСategories)3,
                    CoolCategories = (EnumStore.CoolCategories)3,
                    CoolColors = (EnumStore.CoolColors)2,
                    CoolMaterial = (EnumStore.CoolMaterial)1,
                    Gender = (EnumStore.Gender)1,
                    StoreImages = new List<StoreImage>()
                    {
                        new StoreImage() { Name = "/images/Store/22.jpg" },
                        new StoreImage() { Name = "/images/Store/22.1.jpg" },
                        new StoreImage() { Name = "/images/Store/22.2.jpg" },
                        new StoreImage() { Name = "/images/Store/22.3.jpg" }
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
