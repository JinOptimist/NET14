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

        [HasRole(SiteRole.StoreAdmin)]
        public IActionResult Admin()
        {
            var dbProducts = _productRepository.GetAll();
            var viewModels = _mapper.Map<List<ProductViewModel>>(dbProducts);

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
            var prevUrl = Request.Headers.First(x => x.Key == "Referer").Value;
            return Redirect(prevUrl);
            //return RedirectToAction("Catalog", "Store"); //TO DO change url 
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
                CoolColors = dbProduct.CoolColors.ToString(),
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
                var viewModels = _mapper.Map<List<ProductViewModel>>(dbProducts);

                return View(viewModels);
            }
            if (_category == "Run")
            {
                var dbProducts = _productRepository.GetRun();
                var viewModels = _mapper.Map<List<ProductViewModel>>(dbProducts);

                return View(viewModels);
            }
            if (_category == "Men")
            {
                var dbProducts = _productRepository.GetMen();
                var viewModels = _mapper.Map<List<ProductViewModel>>(dbProducts);

                return View(viewModels);
            }
            if (_category == "Women")
            {
                var dbProducts = _productRepository.GetWomen();
                var viewModels = _mapper.Map<List<ProductViewModel>>(dbProducts);

                return View(viewModels);
            }
            if (_category == "Accessories")
            {
                var dbProducts = _productRepository.GetAccessories();
                var viewModels = _mapper.Map<List<ProductViewModel>>(dbProducts);

                return View(viewModels);
            }
            if (_category == "Bags")
            {
                var dbProducts = _productRepository.GetBags();
                var viewModels = _mapper.Map<List<ProductViewModel>>(dbProducts);

                return View(viewModels);
            }
            return View();


        }
        [HttpGet]
        [IsStoreAdmin]
        public IActionResult AddProduct()
        {
            var dbSize = _sizeRepository.GetAll();
            var model = new AddProductVewModel()
            {
                Sizes = dbSize.Select(x => x.Name).ToList(),
            };


            return View(model);
        }

        [HttpPost]
        [IsStoreAdmin]
        public IActionResult AddProduct([FromBody]AddProductVewModel viewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(viewModel);
            //}

            var dbSized = _sizeRepository.GetByNames(viewModel.CheckedSizes);

            var dbProduct = new Product()
            {
                BrandCategories = viewModel.Brand,
                Name = viewModel.Name,
                Quantity = viewModel.Quantity,
                Price = viewModel.Price,
                CoolCategories = viewModel.Category,
                CoolColors = viewModel.Color,
                CoolMaterial = viewModel.Material,
                Gender = viewModel.Gender,
                Sizes = dbSized
            };

            _productRepository.Save(dbProduct);


            var dbSize = _sizeRepository.GetAll();
            var model = new AddProductVewModel()
            {
                Sizes = dbSize.Select(x => x.Name).ToList(),
            };


            return View(model);
        }
        [HttpGet]
        public IActionResult AddImageProduct(int id)
        {
            var dbProduct = _productRepository.Get(id);
            var model = new AddImageProductVewModel
            {
                Name = dbProduct.Name,
                BrandCategories = dbProduct.BrandCategories.ToString(),
                Images = dbProduct.StoreImages
                .OrderBy(x => x.Odrer)
                .Select(x => x.Url).ToList()
            };


            return View(model);
        }

        [HttpPost]
        public IActionResult AddImageProduct(AddImageProductVewModel viewModel)
        {
            var dbProduct = _productRepository.Get(viewModel.Id);
            var storeImage = new StoreImage()
            {
                Url = viewModel.NewImageUrl,
                Product = dbProduct,
                Odrer = dbProduct.StoreImages.Count() + 1
            };

            _storeimageRepository.Save(storeImage);




            return RedirectToAction("AddImageProduct", new { id = viewModel.Id });
        }
    }
}
