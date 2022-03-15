using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel;
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

            }
        }
    }
}
