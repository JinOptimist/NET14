using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.Models;
using Net14.Web.Models.ArtImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Net14.Web.Controllers
{
    public class ArtImageController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddAnimeImage()
        {
            return View();
        }
        public IActionResult AddCarImage()
        {
            return View();
        }
        public IActionResult AddMusicImage()
        {
            return View();
        }

        public IActionResult CategoriesAnime()
        {
            return View();
        }
        public IActionResult CategoriesCar()
        {
            return View();
        }
        public IActionResult CategoriesMusic()
        {
            return View();
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
               
            };

            return View();

        }
    }
}
