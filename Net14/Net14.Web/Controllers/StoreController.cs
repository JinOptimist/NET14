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
using Net14.Web.Controllers.AutorizeAttribute;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace Net14.Web.Controllers
{
    public class StoreController : Controller
    {
        private BasketRepository _basketRepository;
        private ProductRepository _productRepository;
        private UserService _userService;
        private StoreImageRepository _storeimageRepository;
        private IMapper _mapper;
        private SizeRepository _sizeRepository;
        public StoreController(ProductRepository productRepository,
            StoreImageRepository storeimageRepository,
            BasketRepository basketRepository, UserService userService,
            IMapper imapper, SizeRepository sizeRepository)
        {

            _productRepository = productRepository;
            _storeimageRepository = storeimageRepository;
            _basketRepository = basketRepository;
            _userService = userService;
            _mapper = imapper;
            _sizeRepository = sizeRepository;
        }
        [Authorize]
        public IActionResult MyAccount()
        {
            var user = _userService.GetCurrent();
            var basket = user.Basket ?? new Basket();
            var ProductModel = _mapper.Map<List<ProductViewModel>>(basket.Products);
            var deliveryAdress = _mapper.Map<List<DeliveryAddress>>(user.DeliveryAddress);
            var userAccountModel = new UserAccountViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                City = user.City,
                PhoneNumber = user.PhoneNumber,
                Products = ProductModel,
                DeliveryAddress = deliveryAdress,
                Language=user.Language
            };
            return View(userAccountModel);

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
        [Authorize]
        public IActionResult AddProductToBasket(int productId)
        {
            var user = _userService.GetCurrent();
            var basket = user.Basket ?? new Basket() { User = user, Products = new List<Product>() };
            var product = _productRepository.Get(productId);
            basket.Products.Add(product);
            _basketRepository.Save(basket);
            var prevUrl = Request.Headers.First(x => x.Key == "Referer").Value;
            return Redirect(prevUrl);
        }

        public IActionResult DeleteProductFromBasket(int productId, int userId = 1)
        {
            var basket = _basketRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
            var product = _productRepository.Get(productId);
            basket.Products.Remove(product);
            _basketRepository.Save(basket);
            var prevUrl = Request.Headers.First(x => x.Key == "Referer").Value;
            return Redirect(prevUrl);
            //return RedirectToAction("Basket", "Store");
        }

        public IActionResult Checkout(int userId)
        {
            var basket = _basketRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
            var ViewModel = basket.Products.Select(dbProduct => new ProductViewModel()
            {
                Id = dbProduct.Id,
                BrandCategories= dbProduct.BrandCategories.ToString(),
                Name = dbProduct.Name,
                Price = dbProduct.Price,
                Images = dbProduct.StoreImages.OrderBy(x=>x.Odrer).Select(x => x.Url).ToList()
            }).ToList();

            return View(ViewModel);
        }

        public IActionResult Shoes(int id)
        {
            var dbImages = _storeimageRepository.GetRandom(id);
            var dbProduct = _productRepository.Get(id);
            var model = _mapper.Map<ProductViewModel>(dbProduct);
            model.RandomImages = dbImages.Select(dbImage => new RandomImagesViewModel()
            {
                Url = dbImage.Url,
                ProductId = dbImage.Product.Id,
                Brand = dbImage.Product.BrandCategories.ToString(),
                Name = dbImage.Product.Name,
            }).ToList();

            return View(model);
        }

        public IActionResult Catalog(string category, int page = 1)
        {
            var _category = category;
            var perPage = 8;
            if (string.IsNullOrEmpty(_category))
            {
                var dbProducts = _productRepository.GetAll().Skip((page - 1) * perPage).Take(perPage);
                var viewModels = _mapper.Map<List<ProductViewModel>>(dbProducts);

                var alreadyAddedProductIds = _userService.GetCurrent().Basket.Products.Select(x => x.Id);

                foreach (var productViewModel in viewModels)
                {
                    productViewModel.InBasket = alreadyAddedProductIds.Contains(productViewModel.Id);
                }

                var viewModel = new CatalogPageViewModel()
                {
                    Page = page,
                    Products = viewModels
                };
               
                return View(viewModel);
            }
            else
            {
                var dbProducts = _productRepository.GetCategory(_category);
                var viewModels = _mapper.Map<List<ProductViewModel>>(dbProducts);
                var viewModel = new CatalogPageViewModel()
                {
                    Page = page,
                    Products = viewModels
                };
                return View(viewModel);
            }
        }

        public IActionResult RemoveProduct(int id)
        {
            var basket = _userService.GetCurrent().Basket;
            var product = basket.Products.First(x => x.Id == id);
            basket.Products.Remove(product);
            _basketRepository.Save(basket);
            return Json(true);
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToRoute("default", new { controller = "Store", action = "Index" });
        }
    }
}