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
using Net14.Web.Services;

namespace Net14.Web.Controllers
{ 
    public class SocialFileController : Controller

    {
        private SocialFileRepository _socialFileRepository;    
        private IMapper _mapper;
        private UserService _userService;
        public SocialFileController(IMapper mapper, 
            SocialFileRepository socialFileRepository,
            UserService userService)
        {
            _mapper = mapper;
            _socialFileRepository= socialFileRepository;
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult MyFiles()
        {
            var currentUser = _userService.GetCurrent();
            var dbFiles = _userService.GetCurrent().Files;
            var lastFile = dbFiles.OrderByDescending(file => file.Date);
            var filesViewModel = _mapper.Map<List<FilesViewModel>>(dbFiles);

            var finalModel = new FilesWithLastViewModel()
            {
                Files = filesViewModel,
                LastFiles = _mapper.Map<List<FilesViewModel>>(lastFile)
            };
            finalModel.User = currentUser;

            return View(finalModel);
        }
        [HttpPost]
        public IActionResult MyFiles(string Name, string Url, string Text)
        {
            var currentUser = _userService.GetCurrent();

            var file = new FileSocial()
            {

                Name = Name,
                Url = Url,
                Text = Text,
                Owner = currentUser,
                
            };
            _socialFileRepository.Save(file);

            return RedirectToAction("MyFiles");
        }
        public IActionResult ShowMyFiles(int fileId)
        {
            var Dbfile = _socialFileRepository.Get(fileId);
            var fileViewModel = _mapper.Map<FilesViewModel>(Dbfile);

            return View(fileViewModel);
        }
        
       
    }
}
