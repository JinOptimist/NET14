using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.Services;
using AutoMapper;
using Net14.Web.Models.gallery;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.Models;
using Net14.Web.EfStuff.DbModel.SocialDbModels;

namespace Net14.Web
{
    public class Startup
    {
        public const string AuthName = "SmileCoockie";
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

            services.AddAuthentication(AuthName)
                .AddCookie(AuthName, config =>
                {
                    config.LoginPath = "/SocialAuthentication/Autorization";
                    config.AccessDeniedPath = "/User/AccessDenied";
                    config.Cookie.Name = "SocialMedeiCool";
                });

            RegisterMapper(services);

            services.AddScoped<ImageRepository>(x =>
                new ImageRepository(x.GetService<WebContext>()));

            services.AddScoped<ImageCommentRepository>(x =>
                new ImageCommentRepository(x.GetService<WebContext>()));

            services.AddScoped<SocialUserRepository>(x =>
                new SocialUserRepository(x.GetService<WebContext>()));

            services.AddScoped<SocialPostRepository>(x =>
                new SocialPostRepository(x.GetService<WebContext>()));

            services.AddScoped<SocialFileRepository>(x =>
                new SocialFileRepository(x.GetService<WebContext>()));

            services.AddScoped<SocialCommentRepository>(x =>
                new SocialCommentRepository(x.GetService<WebContext>()));

            services.AddScoped<SocialGroupRepository>(x =>
                new SocialGroupRepository(x.GetService<WebContext>()));

            services.AddScoped<VideoSocialRepository>(x =>
                new VideoSocialRepository(x.GetService<WebContext>()));

            services.AddTransient<YouTubeVideoGetter>();

            services.AddScoped<UserService>(x =>
                new UserService(
                    x.GetService<SocialUserRepository>(),
                    x.GetService<IHttpContextAccessor>()));

            services.AddHttpContextAccessor();

            services.AddControllersWithViews();
        }

        private void RegisterMapper(IServiceCollection services)
        {
            var provider = new MapperConfigurationExpression();

            provider.CreateMap<AddImageVewModel, Image>();
            
            provider.CreateMap<Image, ImageUrlVewModel>()
                .ForMember(nameof(ImageUrlVewModel.Comments),
                opt => opt
                    .MapFrom(dbImage => 
                        dbImage.Comments
                            .Select(c => c.Text)
                            .ToList()));

            provider.CreateMap<FilesViewModel, FileSocial>();

            provider.CreateMap<FileSocial, FilesViewModel>();

            var mapperConfiguration = new MapperConfiguration(provider);
            var mapper = new Mapper(mapperConfiguration);
            services.AddSingleton<IMapper>(x => mapper);
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

            //Who I am
            app.UseAuthentication();

            // Where could I go
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
