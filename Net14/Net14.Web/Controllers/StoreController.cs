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
        private ProductRepository _productRepository;

        private StoreImageRepository _storeimageRepository;
        public StoreController(ProductRepository productRepository, StoreImageRepository storeimageRepository, BasketRepository basketRepository)
        {

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
                Gender = dbProduct.Gender.ToString(),
                Name = dbProduct.Name,
                CoolCategories = dbProduct.CoolCategories.ToString(),
                Quantity = dbProduct.Quantity,
                CoolMaterial = dbProduct.CoolMaterial.ToString(),
                Price = dbProduct.Price,
                CoolColor = dbProduct.CoolColors.ToString(),
                Sizes = dbProduct.Sizes.Select(x => x.Name).ToList(),
                Images = dbProduct.StoreImages
                .OrderBy(x => x.Odrer)
                .Select(x => x.Name).ToList()
            }).ToList();
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
        public IActionResult Basket()
        {
            var b = _basketRepository.Get(1);
            if (b != null) 
            { 
                var ProductModel1 = b.Products.Select(dbProduct => new ProductViewModel()
                {
                Id = dbProduct.Id,
                BrandCategories = dbProduct.BrandCategories.ToString(),
                Name = dbProduct.Name,
                CoolCategories = dbProduct.CoolCategories.ToString(),
                CoolMaterial = dbProduct.CoolMaterial.ToString(),
                Price = dbProduct.Price,
                Images = dbProduct.StoreImages
                .OrderBy(x=>x.Odrer)
                .Select(x => x.Name).ToList()
            }).ToList();

                return View(ProductModel1);
            }
            var ProductModel = new ProductViewModel();

            return View(ProductModel);
        }

        public IActionResult AddProductToBasket(int productId, int userId = 1)
        {
            var basket = _basketRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
            if (basket == null)
            {
                basket = new Basket() { 
                    UserId = userId,
                    Products = new List<Product>()
                };
            }
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
        public IActionResult Checkout(int userId)
        {
            var basket = _basketRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
           var ViewModel =  basket.Products.Select(dbProduct => new ProductViewModel()
            {
                Id = dbProduct.Id,
                Name = dbProduct.Name,
                Price = dbProduct.Price,
                Images = dbProduct.StoreImages.Select(x => x.Name).ToList()
            }).ToList();

            return View(ViewModel);
        }


        public IActionResult Shoes(int id)
        {
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
                .Select(x => x.Name).ToList()
            };

            return View(model);
        }

        public IActionResult Shoes2()
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
                BrandCategories = dbProduct.BrandCategories.ToString(),
                Name = dbProduct.Name,
                CoolCategories = dbProduct.CoolCategories.ToString(),
                CoolMaterial = dbProduct.CoolMaterial.ToString(),
                Price = dbProduct.Price,
                Images = dbProduct.StoreImages
                .OrderBy(x => x.Odrer)
                .Select(x => x.Name).ToList()
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

                Quantity = viewModel.Quantity,

                Price = viewModel.Price,
            };

            _productRepository.Save(dbProduct);

            return View();
        }
    }
}
