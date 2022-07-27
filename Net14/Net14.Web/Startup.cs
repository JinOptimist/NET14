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
using Net14.Web.SignalRHubs;
using System.Reflection;
using Net14.Web.Localize;
using Microsoft.AspNetCore.SignalR;

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

            RegisterRepositories(services);

            RegisterServices(services);

            services.AddHttpContextAccessor();

            services.AddControllersWithViews();

            services.AddSignalR();

            services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();
        }

        private void RegisterServices(IServiceCollection services)
        {
            var autoRegisterType = typeof(AutoRegisterAttribute);
            Assembly
                .GetAssembly(autoRegisterType)
                .GetTypes()
                .Where(type =>
                    type
                        .CustomAttributes
                        .Any(attribute => attribute.AttributeType == autoRegisterType)
                    || type
                        .GetConstructors()
                        .Any(constructor => constructor
                            .CustomAttributes
                            .Any(attribute => attribute.AttributeType == autoRegisterType)))
                .ToList()
                .ForEach(x => SmartRegister(x, services));
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            var baseRepositoryType = typeof(BaseRepository<>);
            Assembly
                .GetAssembly(baseRepositoryType)
                .GetTypes()
                .Where(type => type.BaseType?.IsGenericType ?? false)
                .Where(type => type.BaseType.GetGenericTypeDefinition() == baseRepositoryType)
                .ToList()
                .ForEach(repositoryType => SmartRegister(repositoryType, services));
        }

        private void SmartRegister<T>(IServiceCollection services)
        {
            var type = typeof(T);
            SmartRegister(type, services);
        }

        private void SmartRegister(Type type, IServiceCollection services)
        {
            var constructors = type.GetConstructors();

            var constructor = constructors
                .SingleOrDefault(x => x
                    .CustomAttributes
                    .Any(a => a.AttributeType == typeof(AutoRegisterAttribute)));
            if (constructor == null)
            {
                constructor = constructors
                    .OrderBy(methodInfo => methodInfo.GetParameters().Length)
                    .Last();
            }

            services.AddScoped(
                type,
                serviceProvider =>
                {
                    var parametersData = constructor
                        .GetParameters()
                        .Select(parameter => serviceProvider.GetService(parameter.ParameterType))
                        .ToArray();

                    return constructor.Invoke(parametersData);
                });
        }

        private void RegisterMapper(IServiceCollection services)
        {
            var provider = new MapperConfigurationExpression();

            provider.CreateMap<AddImageVewModel, Image>();
            provider.CreateMap<Basket, ProductViewModel>();
            provider.CreateMap<StoreAddress, StoreAddressViewModel>();
            provider.CreateMap<DeliveryAddress, DeliveryAddressViewModel>();
            provider.CreateMap<Order, OrderViewModel>();
            provider.CreateMap<AddProductVewModel, Product>()
                .ForMember(nameof(Product.BrandCategories),
                    opt => opt
                    .MapFrom(viewModel =>
                       viewModel.Brand))
                .ForMember(nameof(Product.CoolCategories),
                    opt => opt
                    .MapFrom(viewModel =>
                       viewModel.Category))
                .ForMember(nameof(Product.CoolColors),
                    opt => opt
                    .MapFrom(viewModel =>
                       viewModel.Color))
                .ForMember(nameof(Product.CoolMaterial),
                    opt => opt
                    .MapFrom(viewModel =>
                       viewModel.Material));
            provider.CreateMap<Product, AddImageProductVewModel>()
                 .ForMember(nameof(AddImageProductVewModel.BrandCategories),
                    opt => opt
                    .MapFrom(dbProduct =>
                        dbProduct
                        .BrandCategories
                        .ToString()
                        )
                    )
                 .ForMember(nameof(AddImageProductVewModel.Images),
                    opt => opt
                    .MapFrom(dbProduct =>
                        dbProduct
                        .StoreImages
                        .OrderBy(x => x.Odrer)
                        .Select(x =>x.Url)
                        .ToList()
                        )
                    );
            provider.CreateMap<Product, ProductViewModel>()
                .ForMember(nameof(ProductViewModel.CoolCategories),
                    opt => opt
                    .MapFrom(dbProducts =>
                        dbProducts
                            .CoolCategories
                            .ToString()
                        )
                    )
                .ForMember(nameof(ProductViewModel.CoolMaterial),
                    opt => opt
                    .MapFrom(dbProducts =>
                        dbProducts
                            .CoolMaterial
                            .ToString()
                        )
                    )
                .ForMember(nameof(ProductViewModel.CoolColors),
                    opt => opt
                    .MapFrom(dbProducts =>
                        dbProducts
                            .CoolColors
                            .ToString()
                        )
                    )
                .ForMember(nameof(ProductViewModel.Gender),
                    opt => opt
                    .MapFrom(dbProducts =>
                        dbProducts
                            .Gender
                            .ToString()
                        )
                    )
                .ForMember(nameof(ProductViewModel.BrandCategories),
                     opt=>opt
                     .MapFrom(dbProducts=>
                        dbProducts
                            .BrandCategories
                            .ToString()
                        )
                     )
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

            provider.CreateMap<Image, ImageViewModel>();

            provider.CreateMap<FileSocial, FilesViewModel>();

            provider.CreateMap<UserSocial, SocialUserSettingsViewModel>();

            provider.CreateMap<SocialUserSettingsViewModel, UserSocial>();

            provider.CreateMap<UserSocial, SocialUserRecomendationViewModel>();

            provider.CreateMap<SocialMessages, SocialMessageViewModel>();

           
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

            app.UseCors(option =>
            {
                option.AllowAnyOrigin();
                option.AllowAnyHeader();
                option.AllowAnyMethod();
            });

            //Who I am
            app.UseAuthentication();

            // Where could I go
            app.UseAuthorization();

            app.UseMiddleware<LocalizeMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chat");
                endpoints.MapHub<NotificationsHub>("/notif");
                endpoints.MapHub<SocialMessangerHub>("/messages");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
