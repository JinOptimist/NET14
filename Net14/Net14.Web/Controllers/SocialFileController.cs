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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Net14.Web.Controllers
{ 
    public class SocialFileController : Controller

    {
        private SocialFileRepository _socialFileRepository;    
        private IMapper _mapper;
        private UserService _userService;
        private IWebHostEnvironment _webHostEnvironment; 
        public SocialFileController(IMapper mapper, 
            SocialFileRepository socialFileRepository,
            UserService userService,
            IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _socialFileRepository= socialFileRepository;
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
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
        public IActionResult MyFiles(FilesViewModel viewModel)
        {
            var dbFile = new FileSocial();


            if (string.IsNullOrEmpty(viewModel.Url))
            {
                var currentUser = _userService.GetCurrent();

                var dbNewFile = new FileSocial()
                {
                    Name = viewModel.Name,
                    Url = viewModel.Url,
                    Text = viewModel.Text,
                    Owner = currentUser,

                };
                _socialFileRepository.Save(dbNewFile);
            }
            else
            {
                var extention = Path.GetExtension(viewModel.FileImage.FileName);
                var fileName = $"file{dbFile.Id}{extention}";
                var path = Path.Combine(
                    _webHostEnvironment.WebRootPath,
                    "images",
                    "Social",
                    "SocialFilesImages",
                    fileName);

                using (var fs = new FileStream(path, FileMode.CreateNew))
                {
                    viewModel.FileImage.CopyTo(fs);
                }

                dbFile.Url = $"/images/Social/SocialFilesImages/{fileName}";
                _socialFileRepository.Save(dbFile);
            }

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
