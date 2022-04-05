using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.Repositories;



namespace Net14.Web.Controllers
{
    public class SocialFileController : Controller

    {
        private SocialFileRepository _socialFileRepository;
        public SocialFileController(SocialFileRepository socialFileRepository)
        {
            _socialFileRepository = socialFileRepository;
 
        }


        public IActionResult MyFiles()
        {
            return View();
        }
        public IActionResult AllFiles()
        {
            var files = _socialFileRepository.GetAll().Select(x =>
                new FilesViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Text = x.Text,
                    Url = x.Url
                }).ToList();

            return View(files);
        }
        public IActionResult ShowMyFiles(int id)
        {
            var files = _socialFileRepository.Get(id);
            var model = new FilesViewModel()
            {
                Name = files.Name,
                Url = files.Url,
                Text = files.Text,
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult AddFiles()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFiles(FilesViewModel viewModel)
        {
            var dbFiles = new FileSocial()
            {
                Name = viewModel.Name,
                Url = viewModel.Url,
                Text = viewModel.Text,
            };

            _socialFileRepository.Save(dbFiles); // Сохраняйся 

            return View();
        }
        public IActionResult VideoHosting()
        {
            return View();
        }
    }
}
