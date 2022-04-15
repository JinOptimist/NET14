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
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace Net14.Web.Controllers
{
    public class SocialFileController : Controller

    {
        private SocialFileRepository _socialFileRepository;    
        private IMapper _mapper;
        public SocialFileController(IMapper mapper, 
            SocialFileRepository socialFileRepository)
        {
            _mapper = mapper;
            _socialFileRepository= socialFileRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult MyFiles()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MyFiles(string Name, string Url, string Text)
        {
            var file = new FileSocial()
            {
                Name = Name,
                Url = Url,
                Text = Text
            };
            _socialFileRepository.Save(file);

            return View("MyFiles");
        }
        public IActionResult ShowMyFiles(int id)
        {
            var files = _socialFileRepository.Get(id);
            var model = _mapper.Map<FilesViewModel>(files);

            return View(model);
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
       
    }
}
