using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.EnumStore;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models;
using Net14.Web.Models.store;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Controllers
{
    public class StoreController : Controller
    {
        private BasketRepository _basketRepository;
        private ProductRepository _productRepository;
        private UserService _userService;
        private StoreImageRepository _storeimageRepository;
        private IMapper _mapper;
        public StoreController(ProductRepository productRepository, StoreImageRepository storeimageRepository, BasketRepository basketRepository, UserService userService, IMapper imapper)
        {

            _productRepository = productRepository;
            _storeimageRepository = storeimageRepository;
            _basketRepository = basketRepository;
            _userService = userService;
            _mapper = imapper;
        }

        public IActionResult Admin()
        {
            var dbProducts = _productRepository.GetAll();
            var viewModels = _mapper.Map<List<ProductViewModel>>(dbProducts);
            //var viewModels = dbProducts
            //.Select(dbProduct => new ProductViewModel()
            //{
            //    Id = dbProduct.Id,
            //    Gender = dbProduct.Gender.ToString(),
            //    Name = dbProduct.Name,
            //    CoolCategories = dbProduct.CoolCategories.ToString(),
            //    Quantity = dbProduct.Quantity,
            //    CoolMaterial = dbProduct.CoolMaterial.ToString(),
            //    Price = dbProduct.Price,
            //    CoolColor = dbProduct.CoolColors.ToString(),
            //    Sizes = dbProduct.Sizes.Select(x => x.Name).ToList(),
            //    Images = dbProduct.StoreImages
            //    .OrderBy(x => x.Odrer)
            //    .Select(x => x.Name).ToList()
            //}).ToList();
            //var viewModels = dbProducts
            //.Select(dbProduct => new ProductViewModel()
            //{
            //    Id = dbProduct.Id,
            //    Gender = dbProduct.Gender.ToString(),
            //    Name = dbProduct.Name,
            //    CoolCategories = dbProduct.CoolCategories.ToString(),
            //    Quantity = dbProduct.Quantity,
            //    CoolMaterial = dbProduct.CoolMaterial.ToString(),
            //    Price = dbProduct.Price,
            //    CoolColor = dbProduct.CoolColors.ToString(),
            //    Sizes = dbProduct.Sizes.Select(x => x.Name).ToList(),
            //    Images = dbProduct.StoreImages
            //    .OrderBy(x => x.Odrer)
            //    .Select(x => x.Url).ToList()
            //}).ToList();
            return View(viewModels);
        }
        public IActionResult MyAccount()
        {

            return View();
        }

        public IActionResult Index()
        {

            return View();
        }
        [Authorize]
        public IActionResult Basket()
        {
            var user = _userService.GetCurrent();
            var basket = user.Basket ?? new Basket();

            var ProductModel = _mapper.Map<List<ProductViewModel>>(basket.Products);

            return View(ProductModel);
        }

        public IActionResult AddProductToBasket(int productId, int userId = 1)
        {
            //var user = _userService.GetCurrent();
            //var basket = user.Basket ?? new Basket();
            //var product = _productRepository.Get(productId);
            //basket.Products.Add(product);

            var basket = _basketRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
            if (basket == null)
            {
                basket = new Basket()
                {
                    UserId = userId,
                    Products = new List<Product>()
                };
            }

            var product = _productRepository.Get(productId);
            basket.Products.Add(product);
            _basketRepository.Save(basket);
            return RedirectToAction("Catalog", "Store"); //TO DO change url 
        }

        public IActionResult DeleteProductFromBasket(int productId, int userId = 1)
        {
            var basket = _basketRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
            var product = _productRepository.Get(productId);
            basket.Products.Remove(product);
            _basketRepository.Save(basket);
            return RedirectToAction("Basket", "Store");
        }
        public IActionResult Checkout(int userId)
        {
            var basket = _basketRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
            var ViewModel = basket.Products.Select(dbProduct => new ProductViewModel()
            {
                Id = dbProduct.Id,
                Name = dbProduct.Name,
                Price = dbProduct.Price,
                Images = dbProduct.StoreImages.Select(x => x.Url).ToList()
            }).ToList();

            return View(ViewModel);
        }


        public IActionResult Shoes(int id)
        {
            var dbImages = _storeimageRepository.GetRandom(id);
            var dbProduct = _productRepository.Get(id);
            var model = new ProductViewModel()
            {
                Name = dbProduct.Name,
                Gender = dbProduct.Gender.ToString(),
                BrandCategories = dbProduct.BrandCategories.ToString(),
                CoolCategories = dbProduct.CoolCategories.ToString(),
                CoolMaterial = dbProduct.CoolMaterial.ToString(),
                Price = dbProduct.Price,
                CoolColor = dbProduct.CoolColors.ToString(),
                Sizes = dbProduct.Sizes.Select(x => x.Name).ToList(),
                Images = dbProduct.StoreImages
                .OrderBy(x => x.Odrer)
                .Select(x => x.Url).ToList()
            };
            model.RandomImages = dbImages.Select(dbImage => new RandomImagesViewModel()
            {
                Url = dbImage.Url,
                ProductId = dbImage.Product.Id,
                Brand = dbImage.Product.BrandCategories.ToString(),
                Name = dbImage.Product.Name,
            }).ToList();

            return View(model);
        }

        public IActionResult Shoes2()
        {

            return View();
        }

        public IActionResult Catalog(string category)
        {
            var _category = category;
            if (string.IsNullOrEmpty(_category))
            {
                var dbProducts = _productRepository.GetAll();
                var viewModels = dbProducts
                .Select(dbProduct => new ProductViewModel()
                {
                    Id = dbProduct.Id,
                    BrandCategories = dbProduct.BrandCategories.ToString(),
                    Name = dbProduct.Name,
                    CoolCategories = dbProduct.CoolCategories.ToString(),
                    CoolMaterial = dbProduct.CoolMaterial.ToString(),
                    Price = dbProduct.Price,
                    Images = dbProduct.StoreImages
                    .OrderBy(x => x.Odrer)
                    .Select(x => x.Url).ToList()
                }).ToList();
                return View(viewModels);
            }
            if (_category == "Run")
            {
                var dbProducts = _productRepository.GetRun();
                var viewModels = dbProducts
                 .Select(dbProduct => new ProductViewModel()
                 {
                     Id = dbProduct.Id,
                     BrandCategories = dbProduct.BrandCategories.ToString(),
                     Name = dbProduct.Name,
                     CoolCategories = dbProduct.CoolCategories.ToString(),
                     CoolMaterial = dbProduct.CoolMaterial.ToString(),
                     Price = dbProduct.Price,
                     Images = dbProduct.StoreImages
                     .OrderBy(x => x.Odrer)
                     .Select(x => x.Url).ToList()
                 }).ToList();
                return View(viewModels);
            }
            if (_category == "Men")
            {
                var dbProducts = _productRepository.GetMen();
                var viewModels = dbProducts
                 .Select(dbProduct => new ProductViewModel()
                 {
                     Id = dbProduct.Id,
                     BrandCategories = dbProduct.BrandCategories.ToString(),
                     Name = dbProduct.Name,
                     CoolCategories = dbProduct.CoolCategories.ToString(),
                     CoolMaterial = dbProduct.CoolMaterial.ToString(),
                     Price = dbProduct.Price,
                     Images = dbProduct.StoreImages
                     .OrderBy(x => x.Odrer)
                     .Select(x => x.Url).ToList()
                 }).ToList();
                return View(viewModels);
            }
            if (_category == "Women")
            {
                var dbProducts = _productRepository.GetWomen();
                var viewModels = dbProducts
                 .Select(dbProduct => new ProductViewModel()
                 {
                     Id = dbProduct.Id,
                     BrandCategories = dbProduct.BrandCategories.ToString(),
                     Name = dbProduct.Name,
                     CoolCategories = dbProduct.CoolCategories.ToString(),
                     CoolMaterial = dbProduct.CoolMaterial.ToString(),
                     Price = dbProduct.Price,
                     Images = dbProduct.StoreImages
                     .OrderBy(x => x.Odrer)
                     .Select(x => x.Url).ToList()
                 }).ToList();
                return View(viewModels);
            }
            if (_category == "Accessories")
            {
                var dbProducts = _productRepository.GetAccessories();
                var viewModels = dbProducts
                 .Select(dbProduct => new ProductViewModel()
                 {
                     Id = dbProduct.Id,
                     BrandCategories = dbProduct.BrandCategories.ToString(),
                     Name = dbProduct.Name,
                     CoolCategories = dbProduct.CoolCategories.ToString(),
                     CoolMaterial = dbProduct.CoolMaterial.ToString(),
                     Price = dbProduct.Price,
                     Images = dbProduct.StoreImages
                     .OrderBy(x => x.Odrer)
                     .Select(x => x.Url).ToList()
                 }).ToList();
                return View(viewModels);
            }
            if (_category == "Bags")
            {
                var dbProducts = _productRepository.GetBags();
                var viewModels = dbProducts
                 .Select(dbProduct => new ProductViewModel()
                 {
                     Id = dbProduct.Id,
                     BrandCategories = dbProduct.BrandCategories.ToString(),
                     Name = dbProduct.Name,
                     CoolCategories = dbProduct.CoolCategories.ToString(),
                     CoolMaterial = dbProduct.CoolMaterial.ToString(),
                     Price = dbProduct.Price,
                     Images = dbProduct.StoreImages
                     .OrderBy(x => x.Odrer)
                     .Select(x => x.Url).ToList()
                 }).ToList();
                return View(viewModels);
            }
            return View();


        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductVewModel viewModel)
        {

            var dbProduct = new Product()
            {
                Name = viewModel.Name,

                Quantity = viewModel.Quantity,

                Price = viewModel.Price,
            };

            _productRepository.Save(dbProduct);

            return View();
        }
    }
}
