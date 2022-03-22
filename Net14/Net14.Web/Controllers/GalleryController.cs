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
    public class GalleryController : Controller
    {
        private ImageRepository _imageRepository;
        private ImageCommentRepository _commentRepository;

        public GalleryController(ImageRepository imageRepository,
            ImageCommentRepository commentRepository)
        {
            _imageRepository = imageRepository;
            _commentRepository = commentRepository;
        }

        public IActionResult Index()
        {
            var dbImages = _imageRepository.GetAll();

            var viewModels = dbImages
                .Select(dbImage => new ImageViewModel()
                {
                    Id = dbImage.Id,
                    Name = dbImage.Name
                })
                .ToList();

            return View(viewModels);
        }

        public IActionResult ShowImage(int id)
        {
            var dbImage = _imageRepository.Get(id);

            var model = new ImageUrlVewModel()
            {
                Id = dbImage.Id,
                Url = dbImage.Url,
                Comments = dbImage.Comments.Select(x => x.Text).ToList()
            };

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
            var dbImage = new Image()
            {
                Name = viewModel.Name,
                Rate = viewModel.Rate,
                Url = viewModel.Url
            };

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
