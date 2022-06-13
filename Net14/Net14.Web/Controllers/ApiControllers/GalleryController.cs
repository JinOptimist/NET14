using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private IWebHostEnvironment _webHostEnvironment;
        private IMapper _mapper;
        private ImageRepository _imageRepository;

        public GalleryController(IWebHostEnvironment webHostEnvironment,
            ImageRepository imageRepository, IMapper mapper)
        {
            _webHostEnvironment = webHostEnvironment;
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public List<string> GetGirlImages()
        {
            var wwwRootPath = _webHostEnvironment.WebRootPath;

            var galleriesFolderPath = Path
                .Combine(wwwRootPath, "images", "gallery");

            var fileNames = Directory.GetFiles(galleriesFolderPath);

            return fileNames
                .Select(filePath =>
                    $"/images/gallery/{Path.GetFileName(filePath)}")
                .ToList();
        }

        public List<ImageViewModel> GetGirls()
            => _mapper.Map<List<ImageViewModel>>(_imageRepository.GetAll());

        public ImageViewModel CreateGirls(Image girl)
        {
            _imageRepository.Save(girl);
            var viewModel = _mapper.Map<ImageViewModel>(girl);
            return viewModel;
        }

        public bool RemoveGirls(int id)
        {
            _imageRepository.Remove(id);
            return true;
        }
    }
}
