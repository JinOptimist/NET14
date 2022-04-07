using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.Repositories;
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

        private CatigoriRepository _catigoriRepository;
       

        public ArtImageController(CatigoriRepository catigoriRepository)
        {
            _catigoriRepository = catigoriRepository;
            
        }



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


        [HttpGet]
        public IActionResult AddCategori()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategori(AddCategoriVewModel viewModel)
        {
            var dbCategori = new Сategories()
            {
                Name = viewModel.Name,

            };
            _catigoriRepository.Save(dbCategori);
            return View();

        }
    }
}
