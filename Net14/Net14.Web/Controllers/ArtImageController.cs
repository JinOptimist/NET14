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
        private SubCatigoriRepository _subcatigoriRepository;


        public ArtImageController(CatigoriRepository catigoriRepository, SubCatigoriRepository subcatigoriRepository)
        {
            _catigoriRepository = catigoriRepository;
            _subcatigoriRepository = subcatigoriRepository;

    }
 
        public IActionResult Index()
        {

            return View();

        }

        public IActionResult Categories(int id)
        {
            var cat = _catigoriRepository.Get(id);

            var subСategories = cat.SubСategories;

            
            var viewModels = subСategories
                .Select(dbSubCategori => new AddSubCategoriVewModel()
                {
                    Id = dbSubCategori.Id,
                    Name = dbSubCategori.Name
                })
                .ToList();

            return View(viewModels);

        }


        [HttpGet]
        public IActionResult AddCategori()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategori(AddCategoriVewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var dbCategori = new Сategories()
            {
                Name = viewModel.Name,

            };
            _catigoriRepository.Save(dbCategori);
            return View();

        }


        public IActionResult ShowCategories()
        {
            var dbCategori = _catigoriRepository.GetAll();

            var viewModels = dbCategori
                .Select(dbCategori => new AddCategoriVewModel()
                {
                    Id = dbCategori.Id,
                    Name = dbCategori.Name
                })
                .ToList();

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult AddSubCategori(int id)
        {
            var viewModel = new AddSubCategoriVewModel();
            viewModel.CategoriId = id;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddSubCategori(AddSubCategoriVewModel viewModel)
        {
            var categori = _catigoriRepository.Get(viewModel.CategoriId);

            var dbSubCategori = new SubСategories()
            {
                Name = viewModel.Name,
                Catigories = categori
            };

            _subcatigoriRepository.Save(dbSubCategori);
            return View();

        }

    }
}
