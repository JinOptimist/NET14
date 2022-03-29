using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebMaze14;Integrated Security=True;";
            services.AddDbContext<WebContext>(x => x.UseSqlServer(connectString));


            services.AddScoped<ImageRepository>(x =>
                new ImageRepository(x.GetService<WebContext>()));

            services.AddScoped<ImageCommentRepository>(x =>
                new ImageCommentRepository(x.GetService<WebContext>()));

            services.AddScoped<ProductRepository>(x =>
               new ProductRepository(x.GetService<WebContext>()));

            services.AddScoped<ColorRepository>(x =>
              new ColorRepository(x.GetService<WebContext>()));

            services.AddScoped<SizeRepository>(x =>
              new SizeRepository(x.GetService<WebContext>()));
            services.AddScoped<BasketRepository>(x =>
              new BasketRepository(x.GetService<WebContext>()));

            services.AddScoped<StoreImageRepository>(x =>
              new StoreImageRepository(x.GetService<WebContext>()));


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
