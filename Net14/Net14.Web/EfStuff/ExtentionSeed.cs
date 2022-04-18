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
    }
}

