using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Net14.Web.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EnglishController : ControllerBase
    {
        private IWebHostEnvironment _webHostEnvironment;
        public EnglishController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public List<string> GetImagesWithWords ()
        {
            var wwwRootPath = _webHostEnvironment.WebRootPath; //F:\Программирование\NET14\Net14\Net14.Web\wwwroot\

            var englishFolderPath = Path
                .Combine(wwwRootPath, "images", "English");

            var fileNames = Directory.GetFiles(englishFolderPath);

            return fileNames
                .Select(filePath => 
                    $"/images/English/{Path.GetFileName(filePath)}")
                .ToList();
        }
    }
}
