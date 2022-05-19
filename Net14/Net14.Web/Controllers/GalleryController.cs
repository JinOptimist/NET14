using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models;
using Net14.Web.Models.gallery;
using Net14.Web.Services;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace Net14.Web.Controllers
{
    public class GalleryController : Controller
    {
        private ImageRepository _imageRepository;
        private ImageCommentRepository _commentRepository;
        private UserService _userService;
        private IMapper _mapper;
        private IWebHostEnvironment _webHostEnvironment;

        public GalleryController(ImageRepository imageRepository,
            ImageCommentRepository commentRepository,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment, 
            UserService userService)
        {
            _imageRepository = imageRepository;
            _commentRepository = commentRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _userService = userService;
        }

        public IActionResult Index(int page = 1, int perPage = 3)
        {
            var dbImages = _imageRepository.GetAll();

            var imagesViewModels = dbImages
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .Select(_mapper.Map<ImageViewModel>)
                .ToList();

            var viewModel = new IndexGalleryViewModel()
            {
                Page = page,
                PerPage = perPage,
                TotalCount = dbImages.Count,
                Images = imagesViewModels
            };
            return View(viewModel);
        }

        public IActionResult ShowImage(int id)
        {
            var dbImage = _imageRepository.Get(id);

            var model = _mapper.Map<ImageUrlVewModel>(dbImage);
            //var model = new ImageUrlVewModel()
            //{
            //    Id = dbImage.Id,
            //    Url = dbImage.Url,
            //    Comments = dbImage.Comments.Select(x => x.Text).ToList()
            //};

            return View(model);
        }

        public IActionResult FindPair()
        {
            return View();
        }

        public IActionResult UrlsForFindPair()
        {
            //Thread.Sleep(3000);
            var list = new List<string>
            {
                "http://localhost:42059/images/gallery/girl1.webp",
                "http://localhost:42059/images/gallery/girl2.jpg",
                "http://localhost:42059/images/gallery/girl3.jfif",
                "http://localhost:42059/images/gallery/girl4.png",
                "http://localhost:42059/images/gallery/girl5.png",
                "http://localhost:42059/images/gallery/girl6.jfif",
            };
            return Json(list);
        }

        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddImage(AddImageVewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var dbImage = _mapper.Map<Image>(viewModel);
            var adminComment = new ImageComment()
            {
                Text = "First comment"
            };
            dbImage.Comments = new List<ImageComment>() { adminComment };

            _imageRepository.Save(dbImage);

            var extension = Path.GetExtension(viewModel.GirlImage.FileName);
            var fileName = $"girl{dbImage.Id}{extension}";
            var path = Path.Combine(
                _webHostEnvironment.WebRootPath,
                "images",
                "gallery",
                fileName);
            using (var fs = new FileStream(path, FileMode.CreateNew))
            {
                viewModel.GirlImage.CopyTo(fs);
            }

            dbImage.Url = $"/images/gallery/{fileName}";
            _imageRepository.Save(dbImage);

            return View();
        }

        public IActionResult AddComment(int imageId, string text)
        {
            var image = _imageRepository.Get(imageId);
            var comment = new ImageComment()
            {
                Text = text,
                Image = image
            };

            _commentRepository.Save(comment);

            return RedirectToAction("ShowImage", new { id = imageId });
        }
    }
}
