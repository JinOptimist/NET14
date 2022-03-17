using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel;
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
        private WebContext _webContext;

        public StoreController(WebContext webContext)
        {
          _webContext = webContext;
        }

        public IActionResult CatalogTest()
        {
            var dbProducts=_webContext.Products.ToList();
            var viewModels = dbProducts
            .Select(dbProduct => new ProductViewModel()
            {
                Id = dbProduct.Id,
                Name = dbProduct.Name,
                Url=dbProduct.Url
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
        public IActionResult Shoes()
        {

            return View();
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
                Url = viewModel.Url,
                Category=viewModel.Category,
                Quantity = viewModel.Quantity,
                Material=viewModel.Material
            };

            _webContext.Products.Add(dbProduct);

            _webContext.SaveChanges();

            return View();
        }
    }
}
