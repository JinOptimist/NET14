using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models;
using Net14.Web.Models.gallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Controllers
{
    public class GalleryController : Controller
    {
        private ImageRepository _imageRepository;
        private ImageCommentRepository _commentRepository;
        private IMapper _mapper;

        public GalleryController(ImageRepository imageRepository,
            ImageCommentRepository commentRepository, 
            IMapper mapper)
        {
            _imageRepository = imageRepository;
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public IActionResult Index(int page = 1)
        {
            var perPage = 2;
            var dbImages = _imageRepository
                .GetAll()
                .Skip((page - 1) * perPage)
                .Take(perPage);

            var imagesViewModels = dbImages
                .Select(dbImage => new ImageViewModel()
                {
                    Id = dbImage.Id,
                    Name = dbImage.Name
                })
                .ToList();

            var viewModel = new IndexGalleryViewModel()
            {
                Page = page,
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

        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddImage(AddImageVewModel viewModel)
        {
            var dbImage = _mapper.Map<Image>(viewModel);
            //var dbImage = new Image()
            //{
            //    Name = viewModel.Name,
            //    Rate = viewModel.Rate,
            //    Url = viewModel.Url
            //};

            var adminComment = new ImageComment()
            {
                Text = "First comment"
            };

            dbImage.Comments = new List<ImageComment>() { adminComment };

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
