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
                SeedProduct(scope);

            }

            return host;
        }
        private static void SeedProduct(IServiceScope scope)
        {
            var productRepository = scope.ServiceProvider.GetService<ProductRepository>();
            var storeImageRepository = scope.ServiceProvider.GetService<StoreImageRepository>();
             
            if (!productRepository.Any())
            {
                var product1 = new Product()
                {
                    Id = 1,
                    Name = "Air Force 1 ’07 W White/Black",
                    Quantity = 1,
                    Price = 120,
                    BrandCategories = (EnumStore.BrandСategories)1,
                    CoolCategories= (EnumStore.CoolCategories)4,
                    CoolColors= (EnumStore.CoolColors)1,
                    CoolMaterial= (EnumStore.CoolMaterial)1,
                    Gender= (EnumStore.Gender)2,
                };
                var product2 = new Product()
                {
                    Id = 2,
                    Name = "Air Force 1 LV8 W White",
                    Quantity = 3,
                    Price = 133,
                    BrandCategories = (EnumStore.BrandСategories)1,
                    CoolCategories = (EnumStore.CoolCategories)4,
                    CoolColors = (EnumStore.CoolColors)1,
                    CoolMaterial = (EnumStore.CoolMaterial)1,
                    Gender = (EnumStore.Gender)2
                };
                var product3 = new Product()
                {
                    Id = 3,
                    Name = "Air Force 1 LV8 1 HO20 W",
                    Quantity = 3,
                    Price = 170,
                    BrandCategories = (EnumStore.BrandСategories)1,
                    CoolCategories = (EnumStore.CoolCategories)4,
                    CoolColors = (EnumStore.CoolColors)1,
                    CoolMaterial = (EnumStore.CoolMaterial)1,
                    Gender = (EnumStore.Gender)2,
                };
                var product4 = new Product()
                {
                    Id = 4,
                    Name = "Air Max 270 React W Grey",
                    Quantity = 1,
                    Price = 110,
                    BrandCategories = (EnumStore.BrandСategories)1,
                    CoolCategories = (EnumStore.CoolCategories)4,
                    CoolColors = (EnumStore.CoolColors)1,
                    CoolMaterial = (EnumStore.CoolMaterial)2,
                    Gender = (EnumStore.Gender)2,
                };
                var product5 = new Product()
                {
                    Id = 5,
                    Name = "Originals Supercourt 2 White",
                    Quantity = 1,
                    Price = 115,
                    BrandCategories = (EnumStore.BrandСategories)2,
                    CoolCategories = (EnumStore.CoolCategories)4,
                    CoolColors = (EnumStore.CoolColors)1,
                    CoolMaterial = (EnumStore.CoolMaterial)1,
                    Gender = (EnumStore.Gender)1,
                };
                var product6 = new Product()
                {
                    Id = 6,
                    Name = "Gel-Lyte III RE Grey",
                    Quantity = 3,
                    Price = 170,
                    BrandCategories = (EnumStore.BrandСategories)4,
                    CoolCategories = (EnumStore.CoolCategories)4,
                    CoolColors = (EnumStore.CoolColors)3,
                    CoolMaterial = (EnumStore.CoolMaterial)4,
                    Gender = (EnumStore.Gender)1,
                };
                var product7 = new Product()
                {
                    Id = 7,
                    Name = "Originals Niteball Black",
                    Quantity = 2,
                    Price = 188,
                    BrandCategories = (EnumStore.BrandСategories)2,
                    CoolCategories = (EnumStore.CoolCategories)4,
                    CoolColors = (EnumStore.CoolColors)4,
                    CoolMaterial = (EnumStore.CoolMaterial)2,
                    Gender = (EnumStore.Gender)1,
                };
                var product8 = new Product()
                {
                    Id = 8,
                    Name = "Shadow 5000 Yellow",
                    Quantity = 2,
                    Price = 110,
                    BrandCategories = (EnumStore.BrandСategories)5,
                    CoolCategories = (EnumStore.CoolCategories)4,
                    CoolColors = (EnumStore.CoolColors)6,
                    CoolMaterial = (EnumStore.CoolMaterial)4,
                    Gender = (EnumStore.Gender)1,
                    
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
            if (!storeImageRepository.Any())
            {
                var storeImage1 = new StoreImage()
                {
                    Name= "/images/Store/11.jpg",
                    
                };
            }
        }
    }
}
