using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models;
using Net14.Web.Models.store;
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
        private ColorRepository _colorRepository;
        private ProductRepository _productRepository;

        private StoreImageRepository _storeimageRepository;
        public StoreController(ProductRepository productRepository, ColorRepository colorRepository, StoreImageRepository storeimageRepository,BasketRepository basketRepository)
        {
            _colorRepository = colorRepository;
            _productRepository = productRepository;
            _storeimageRepository = storeimageRepository;
            _basketRepository = basketRepository;

        }

        public IActionResult Admin()
        {
            var dbProducts = _productRepository.GetAll();
            var viewModels = dbProducts
            .Select(dbProduct => new ProductViewModel()
            {
                Id = dbProduct.Id,
                Name = dbProduct.Name,

       

                Category=dbProduct.Category,
                Quantity=dbProduct.Quantity,
                Material=dbProduct.Material,
                Price=dbProduct.Price,

                Colors = dbProduct.Colors.Select(x => x.Name).ToList(),
                Sizes = dbProduct.Sizes.Select(x => x.Name).ToList(),
                Images = dbProduct.StoreImages.Select(x => x.Name).ToList()
            }).ToList();
            return View(viewModels);
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Basket()
        {
            var b = _basketRepository.Get(1);
            var ProductViewModel = b.Products.Select(dbProduct => new ProductViewModel()
            {
                Id = dbProduct.Id,
                Name = dbProduct.Name,
                
                Category = dbProduct.Category,
                Material = dbProduct.Material,
                Price = dbProduct.Price,

            }).ToList();

            return View(ProductViewModel);
        }

        public IActionResult AddProductToBasket(int productId, int userId = 1)
        {
            var basket = _basketRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
            var product = _productRepository.Get(productId);
            basket.Products.Add(product);
            _basketRepository.Save(basket);
            return RedirectToAction("Catalog", "Store");
        }

        public IActionResult DeleteProductFromBasket(int productId, int userId = 1)
        {
            var basket = _basketRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
            var product = _productRepository.Get(productId);
            basket.Products.Remove(product);
            _basketRepository.Save(basket);
            return RedirectToAction("Basket", "Store");
        }

        public IActionResult Shoes(int id)
        {
            var dbProduct = _productRepository.Get(id);
            var model = new ProductViewModel()
            {
                Name = dbProduct.Name,
                Category = dbProduct.Category,
                Material = dbProduct.Material,
                Price = dbProduct.Price,



                Colors=dbProduct.Colors.Select(x => x.Name).ToList(),
                Sizes = dbProduct.Sizes.Select(x => x.Name).ToList(),
                Images=dbProduct.StoreImages.Select(x => x.Name).ToList()
         };
            return View(model);
        }

        public IActionResult Shoes2()
        {

            return View();
        }
        public IActionResult Checkout()
        {

            return View();
        }
        public IActionResult Catalog()
        {
            var dbProducts = _productRepository.GetAll();
            var viewModels = dbProducts
            .Select(dbProduct => new ProductViewModel()
            {
                Id = dbProduct.Id,
                Name = dbProduct.Name,
                Category = dbProduct.Category,
                Material = dbProduct.Material,
                Price = dbProduct.Price,
                Images = dbProduct.StoreImages.Select(x => x.Name).ToList()

            }).ToList();
            return View(viewModels);

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

                
                Category = viewModel.Category,


                Quantity = viewModel.Quantity,
                Material = viewModel.Material,
                Price = viewModel.Price,

            };

            _productRepository.Save(dbProduct);

            return View();
        }
    }
}
