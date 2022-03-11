using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.Models;
using Net14.Web.Models.gallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Controllers
{
    public class GalleryController : Controller
    {
        private WebContext _webContext;

        public GalleryController(WebContext webContext)
        {
            _webContext = webContext;
        }

        public IActionResult Index()
        {
            var dbImages = _webContext.Images.ToList();

            var viewModels = dbImages
                .Select(dbImage => new ImageViewModel()
                {
                    Id = dbImage.Id,
                    Name = dbImage.Name
                })
                .ToList();

            return View(viewModels);
        }

        public IActionResult ShowImage(int id)
        {
            var dbImage = _webContext
                .Images
                .First(x => x.Id == id);

            var model = new ImageUrlVewModel()
            {
                Url = dbImage.Url,
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddImage(AddImageVewModel viewModel)
        {
            var dbImage = new Image()
            {
                Name = viewModel.Name,
                Rate = viewModel.Rate,
                Url = viewModel.Url
            };

            _webContext.Images.Add(dbImage);

            _webContext.SaveChanges();

            return View();
        }
    }
}
