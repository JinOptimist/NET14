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
using AutoMapper;
using Net14.Web.Models.gallery;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.Models.store;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.Models;

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
                 config.AccessDeniedPath = "/SocialAuthentication/AccessDenied";
                 config.Cookie.Name = "SocialMedeiCool";
             });

            RegisterMapper(services);

            services.AddScoped<ImageRepository>(x =>
                new ImageRepository(x.GetService<WebContext>()));

            services.AddScoped<ImageCommentRepository>(x =>
                new ImageCommentRepository(x.GetService<WebContext>()));

            services.AddScoped<ProductRepository>(x =>
               new ProductRepository(x.GetService<WebContext>()));

            services.AddScoped<SizeRepository>(x =>
              new SizeRepository(x.GetService<WebContext>()));
            services.AddScoped<BasketRepository>(x =>

              new BasketRepository(x.GetService<WebContext>()));

            services.AddScoped<StoreImageRepository>(x =>
              new StoreImageRepository(x.GetService<WebContext>()));

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

            services.AddScoped<RecomendationsService>(x =>
                new RecomendationsService(
                    x.GetService<SocialUserRepository>(),
                    x.GetService<IMapper>(),
                    x.GetService<UserService>(),
                    x.GetService<SocialGroupRepository>()));

            services.AddScoped<YouTubeVideoService>();

            services.AddScoped<UserService>(x =>
                new UserService(
                    x.GetService<SocialUserRepository>(),
                    x.GetService<IHttpContextAccessor>(),
                    x.GetService<IMapper>()));
                    
            services.AddScoped<UserFriendRequestRepository>(x =>
                new UserFriendRequestRepository(x.GetService<WebContext>()));

            services.AddScoped<FriendRequestService>(x =>
                new FriendRequestService(
                    x.GetService<UserFriendRequestRepository>(),
                    x.GetService<SocialUserRepository>()));
            services.AddScoped<CurrencyService>(x =>
                new CurrencyService());
            services.AddHttpContextAccessor();

            services.AddControllersWithViews();
        }

        private void RegisterMapper(IServiceCollection services)
        {
            var provider = new MapperConfigurationExpression();

            provider.CreateMap<AddImageVewModel, Image>();
            provider.CreateMap<Basket, ProductViewModel>();

            provider.CreateMap<Product, ProductViewModel>()
                .ForMember(nameof(ProductViewModel.Images),
                    opt => opt
                    .MapFrom(dbProducts => 
                        dbProducts
                            .StoreImages
                            .OrderBy(x => x.Odrer)
                            .Select(x => x.Url)
                            .ToList()
                        )
                    )
                .ForMember(nameof(ProductViewModel.Sizes),
                    opt => opt
                    .MapFrom(dbProducts =>
                        dbProducts
                            .Sizes
                            .Select(x => x.Name)
                            .ToList()
                        )
                    );


            provider.CreateMap<Image, ImageUrlVewModel>()
                .ForMember(nameof(ImageUrlVewModel.Comments),
                opt => opt
                    .MapFrom(dbImage =>
                        dbImage.Comments
                            .Select(c => c.Text)
                            .ToList()));

            provider.CreateMap<PostSocial, SocialPostViewModel>()
                .ForMember(nameof(SocialPostViewModel.UserId),
                    post => post
                        .MapFrom(dbPost =>
                            dbPost.User.Id))
            .ForMember(nameof(SocialPostViewModel.UserPhoto),
                    post => post
                        .MapFrom(dbPost =>
                            dbPost.User.UserPhoto))
            .ForMember(nameof(SocialPostViewModel.FirstName),
                    post => post
                        .MapFrom(dbPost =>
                            dbPost.User.FirstName));

            provider.CreateMap<GroupSocial, SocialGroupViewModel>()
                .ForMember(nameof(SocialGroupViewModel.Tags),
                    group => group
                        .MapFrom(dbGroup =>
                            dbGroup.Tags.Select(tag => tag.Tag)));

            provider.CreateMap<SocialUserRegistrationViewModel, UserSocial>();

            provider.CreateMap<UserFriendRequest, FriendRequestViewModel>();


            provider.CreateMap<UserSocial, SocialUserViewModel>();
            provider.CreateMap<SocialComment, SocialCommentViewModel>();
            provider.CreateMap<UserSocial, SocialProfileViewModel>();
            provider.CreateMap<SocialCommentViewModel, SocialUserViewModel>();
                
            provider.CreateMap<FilesViewModel, FileSocial>();

            provider.CreateMap<FileSocial, FilesViewModel>();

            provider.CreateMap<UserSocial, SocialUserSettingsViewModel>();

            provider.CreateMap<SocialUserSettingsViewModel, UserSocial>();



            provider.CreateMap<UserSocial, SocialUserRecomendationViewModel>();

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
