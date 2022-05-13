using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public GalleryController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
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
    }
}
