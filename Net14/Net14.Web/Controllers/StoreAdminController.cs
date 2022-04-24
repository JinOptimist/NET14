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
using System.Collections.Generic;
using Net14.Web.Controllers.AutorizeAttribute;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using System.Linq;

namespace Net14.Web.Controllers
{
    [HasRole(SiteRole.StoreAdmin)]
    public class StoreAdminController : Controller
    {
        private BasketRepository _basketRepository;
        private ProductRepository _productRepository;
        private UserService _userService;
        private StoreImageRepository _storeimageRepository;
        private IMapper _mapper;
        private SizeRepository _sizeRepository;
        public StoreAdminController(ProductRepository productRepository,
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

        public IActionResult Admin()
        {
            var dbProducts = _productRepository.GetAll();
            var viewModels = _mapper.Map<List<ProductViewModel>>(dbProducts);

            return View(viewModels);
        }
       
        [HttpGet]
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
        public IActionResult AddProduct( AddProductVewModel viewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(viewModel);
            //}

            var dbSized = _sizeRepository.GetByNames(viewModel.CheckedSizes);
            var dbProduct=_mapper.Map<Product>(viewModel);
            dbProduct.Sizes = dbSized;
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
            var model=_mapper.Map<AddImageProductVewModel>(dbProduct);
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
