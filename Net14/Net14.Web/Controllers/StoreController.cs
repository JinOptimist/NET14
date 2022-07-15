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
        private OrderRepository _orderRepository;
        private DeliveryAddressRepository _deliveryAddressRepository;
        private StoreAddressRepository _storeAddressRepository;

        public StoreController(ProductRepository productRepository,
            StoreImageRepository storeimageRepository,
            BasketRepository basketRepository, UserService userService,
            IMapper imapper, SizeRepository sizeRepository, OrderRepository orderRepository, DeliveryAddressRepository deliveryAddressRepository,
            StoreAddressRepository storeAddressRepository)
        {
            _orderRepository = orderRepository;
            _deliveryAddressRepository = deliveryAddressRepository;
            _storeAddressRepository = storeAddressRepository;
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
                Language = user.Language
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
        public IActionResult AddProductToBasket(int productId, string urlToredirect)
        {
            var user = _userService.GetCurrent();
            var basket = user.Basket ?? new Basket() { User = user, Products = new List<Product>() };
            var product = _productRepository.Get(productId);
            basket.Products.Add(product);
            _basketRepository.Save(basket);
            //var prevUrl = Request.Headers.First(x => x.Key == "Referer").Value;
            return Redirect(urlToredirect);
        }

        public IActionResult DeleteProductFromBasket(int productId, int userId = 1)
        {
            var basket = _basketRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
            var product = _productRepository.Get(productId);
            basket.Products.Remove(product);
            _basketRepository.Save(basket);
            var prevUrl = Request.Headers.First(x => x.Key == "Referer").Value;
            return Redirect(prevUrl);
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            var dbStoreAdress = _storeAddressRepository.GetAll();
            var user = _userService.GetCurrent();
            var deliveryAdress = _mapper.Map<List<DeliveryAddressViewModel>>(user.DeliveryAddress);
            var storeAdress = _mapper.Map<List<StoreAddressViewModel>>(dbStoreAdress);
            var dbProducts = user.Basket.Products.Select(dbProduct => new ProductViewModel()
            {
                Id = dbProduct.Id,
                BrandCategories = dbProduct.BrandCategories.ToString(),
                Name = dbProduct.Name,
                Price = dbProduct.Price,
                Images = dbProduct.StoreImages.OrderBy(x => x.Odrer).Select(x => x.Url).ToList()
            }).ToList();
            var checoutViewModel = new ChecoutViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Products = dbProducts,
                DeliveryAddress = deliveryAdress,
                StoreAddress = storeAdress
            };


            return View(checoutViewModel);
        }
        [HttpPost]
        public IActionResult Checkout(ChecoutViewModel checoutViewModel)
        {

            var dbOrder = new Order
            {
                OrderDate = DateTime.Now,
                StatusOrder = StatusOrder.New,
                Sum = checoutViewModel.Sum,
                Comment = checoutViewModel.Comment,
                UserSocial = _userService.GetCurrent(),
                DeliveryAddress = _deliveryAddressRepository.Get(checoutViewModel.CheckedDeliveryAddressId),
                DeliveryOrPickup = checoutViewModel.DeliveryOrPickup,
                StoreAddress = _storeAddressRepository.Get(checoutViewModel.CheckedStoreAddressId),
                Products = new List<Product>()
            };

            _userService.GetCurrent().Basket.Products.ForEach(x => dbOrder.Products.Add(x));

            _orderRepository.Save(dbOrder);
            var basket = _userService.GetCurrent().Basket;
            basket.Products.Clear();
            _basketRepository.Save(basket);

            return View();
        }

        public IActionResult Shoes(int id)
        {
            var user = _userService.GetCurrent();
            var dbImages = _storeimageRepository.GetRandom(id);
            var dbProduct = _productRepository.Get(id);
            var model = _mapper.Map<ProductViewModel>(dbProduct);
            if (user != null)
            {
                var alreadyAddedProductIds = _userService.GetCurrent().Basket.Products.Select(x => x.Id);
                model.InBasket = alreadyAddedProductIds.Contains(model.Id);
            }
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
                var user = _userService.GetCurrent();
                if (user != null)
                {
                    var alreadyAddedProductIds = _userService.GetCurrent().Basket.Products.Select(x => x.Id);

                    foreach (var productViewModel in viewModels)
                    {
                        productViewModel.InBasket = alreadyAddedProductIds.Contains(productViewModel.Id);
                    }
                }
                var viewModel = new CatalogPageViewModel()
                {
                    Page = page,
                    Products = viewModels,
                    CatalogCategory = _category
                };

                return View(viewModel);
            }
            else
            {
                var dbProducts = _productRepository.GetCategory(_category);
                var viewModels = _mapper.Map<List<ProductViewModel>>(dbProducts);
                var user = _userService.GetCurrent();
                if (user != null)
                {
                    var alreadyAddedProductIds = _userService.GetCurrent().Basket.Products.Select(x => x.Id);

                    foreach (var productViewModel in viewModels)
                    {
                        productViewModel.InBasket = alreadyAddedProductIds.Contains(productViewModel.Id);
                    }
                }
                var viewModel = new CatalogPageViewModel()
                {
                    Page = page,
                    Products = viewModels,
                    CatalogCategory = _category
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