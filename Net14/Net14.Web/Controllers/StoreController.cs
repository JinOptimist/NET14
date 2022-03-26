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
        
        private ColorRepository _colorRepository;
        private ProductRepository _productRepository;
        public StoreController(ProductRepository productRepository,ColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
            _productRepository = productRepository;
        }

        public IActionResult Admin()
        {
            var dbProducts= _productRepository.GetAll();
            var viewModels = dbProducts
            .Select(dbProduct => new ProductViewModel()
            {
                Id = dbProduct.Id,
                Name = dbProduct.Name,
                Url=dbProduct.Url,
                Category=dbProduct.Category,
                Quantity=dbProduct.Quantity,
                Material=dbProduct.Material,
                Price=dbProduct.Price,
                
            }).ToList();
            return View(viewModels);
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Basket()
        {

            return View();
        }
        public IActionResult Shoes(int id)
        {
            var dbProduct= _productRepository.Get(id);
            var model = new ProductViewModel()
            {
                Name = dbProduct.Name,
                Url = dbProduct.Url,
                Category = dbProduct.Category,
                Material = dbProduct.Material,
                Price = dbProduct.Price,
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
                Url = dbProduct.Url,
                Category = dbProduct.Category,
                Material = dbProduct.Material,
                Price = dbProduct.Price,

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
                Url = viewModel.Url,
                Category=viewModel.Category,
                Quantity = viewModel.Quantity,
                Material=viewModel.Material,
                Price=viewModel.Price,
              
            };

            _productRepository.Save(dbProduct);

            return View();
        }
    }
}
