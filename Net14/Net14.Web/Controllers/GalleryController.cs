using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            var models = new List<ImageViewModel>() { 
                new ImageViewModel()
                {
                    Id = 1,
                    Name = "nice"
                },
                 new ImageViewModel()
                {
                    Id = 2,
                    Name = "dark"
                },
            };
            return View(models);
        }

        public IActionResult AddImage(int id)
        {
            var model = new ImageUrlVewModel();
            switch (id)
            {
                case 1:
                    model.Url = "/images/gallery/girl1.webp";
                    break;
                case 2:
                    model.Url = "/images/gallery/girl2.jpg";
                    break;
            }
            return View(model);
        }
    }
}
