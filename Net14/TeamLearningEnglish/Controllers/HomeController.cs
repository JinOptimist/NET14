using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TeamLearningEnglish.EfStuff;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.EfStuff.Repository;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.Controllers
{
    public class HomeController : Controller
    {
        private BooksRepository _booksRepository;
        private IMapper _mapper;

        public HomeController(
            BooksRepository booksRepository,
            IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Books()
        {
            var dbModels = _booksRepository.GetAll();

            var viewModels = dbModels.Select(dbModel => new BookViewModel
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                Text = dbModel.Text
            }).ToList();

            return View(viewModels);
        }
        public IActionResult ShowBook(int id, int page = 1)
        {
            var dbModel = _booksRepository.Get(id);

            var bookViewModel = _mapper.Map<BookViewModel>(dbModel);

            var maxSymbvalOnePage = 1000; 
            var symbvals = bookViewModel.Text.ToCharArray();  

            var model = symbvals
                .Skip((page - 1) * maxSymbvalOnePage)
                .Take(maxSymbvalOnePage)
                .ToList();
            var viewModel = new IndexBookViewModel()
            {
                Page = page,
                Text = model,
                Book = bookViewModel
            };

            return View(viewModel);
        }
        


    }
}
