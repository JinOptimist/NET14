using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Net14.Web.Controllers
{
    public class CalendarController : Controller
    {
        private WebContext _webContext;

        public CalendarController(WebContext webContext)
        {
            _webContext = webContext;
        }
        public IActionResult Index()
        {
            var model = new List<string>() { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            foreach (var item in model)
            {
                View(item);
            }
            return View(model);
        }
        public IActionResult ShowNote()
        {
            var dbNotes = _webContext
                .Notes
                .ToList();
            var noteViewModels = dbNotes
                .Select(dbNote => new NoteViewModel()
                {
                    Name = dbNote.Name,
                    Text = dbNote.Text,
                    Date = dbNote.Date,
                })
                .ToList();

            return View(noteViewModels);
        }

        [HttpGet]
        public IActionResult AddNote()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNote(AddNoteViewModel viewModel)
        {
            var dbNote = new Note()
            {
                Name = viewModel.Name,
                Text = viewModel.Text,
                Date = viewModel.Date
            };

            _webContext.Notes.Add(dbNote);

            _webContext.SaveChanges();

            return View();
        }
        
    }
}
