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

            if (!productRepository.Any())
            {
                var product = new Product()
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

                productRepository.Save(product);
            };
        }
    }
}
