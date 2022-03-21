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
        
        public IActionResult CalendarView(CalendarViewModel CalViewModel)
        {
            var dayOfWeek = new DateTime(CalViewModel.Year, CalViewModel.MonthNumber, 1).DayOfWeek;
            var monthView = new List<string>();
            int daysCount = DateTime.DaysInMonth(CalViewModel.Year, CalViewModel.MonthNumber);
            switch (dayOfWeek.ToString())
            {
                case "Monday":
                    break;
                case "Tuesday":
                    monthView.Add("_");
                    break;
                case "Wednesday":
                    monthView.Add("_");
                    monthView.Add("_");
                    break;
                case "Thursday":
                    monthView.Add("_");
                    monthView.Add("_");
                    monthView.Add("_");
                    break;
                case "Friday":
                    monthView.Add("_");
                    monthView.Add("_");
                    monthView.Add("_");
                    monthView.Add("_");
                    break;
                case "Saturday":
                    monthView.Add("_");
                    monthView.Add("_");
                    monthView.Add("_");
                    monthView.Add("_");
                    monthView.Add("_");
                    break;
                case "Sunday":
                    monthView.Add("_");
                    monthView.Add("_");
                    monthView.Add("_");
                    monthView.Add("_");
                    monthView.Add("_");
                    monthView.Add("_");
                    break;
                default:
                    break;
            }
            for (int i = 0; i < daysCount; i++)
            {
                monthView.Add(CalViewModel.DayNumber.ToString());
                CalViewModel.DayNumber++;
            }
            return View(monthView);
        }
        public IActionResult ChangeMonth(CalendarViewModel CalViewModel)
        {
            CalViewModel.MonthNumber--;
            CalendarView(CalViewModel);
            return View();
        }
    }
}
