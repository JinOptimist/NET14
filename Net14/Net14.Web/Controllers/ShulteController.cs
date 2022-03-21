using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel.DbShulte;
using Net14.Web.Models.Shulte;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Net14.Web.Controllers
{
    public class ShulteController : Controller
    {
        private WebContext _webContext;

        public ShulteController(WebContext webContext)
        {
            _webContext = webContext;
        }
        public IActionResult Main()
        {
            var random = new RandomNumberViewModel();
            var numbers = new List<int>(random.Random());
            return View(numbers);
        }
        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddComment(CommentsViewModel viewModel)
        {
            var dbComment = new CommentsForShulte()
            {
                Comment = viewModel.Comment
            };

            _webContext.CommentsForShulte.Add(dbComment);

            _webContext.SaveChanges();

            return View();
        }
        public IActionResult index()
        {
            var dbComments = _webContext.CommentsForShulte.ToList();

            var viewModels = dbComments
                .Select(dbImage => new CommentsViewModel()
                {
                    Id = dbImage.Id,
                    Comment = dbImage.Comment
                })
                .ToList();

            return View(viewModels);
        }
        
    }
}
