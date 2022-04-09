using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models;
using Net14.Web.Models.Calendar;
using Net14.Web.Models.Calendar.Test;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Controllers
{
    public class CalendarController : Controller
    {
        private DaysRepository _DaysRepository;
        private DaysNoteRepository _DaysNoteRepository;

        public CalendarController(DaysNoteRepository daysNoteRepository, DaysRepository daysRepository)
        {
            _DaysNoteRepository = daysNoteRepository;
            _DaysRepository = daysRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestCalendar(int year=2022,int month=4)
        {
            if (month < 1)
            {
                month = 12;
                year--;
            }
            if (month > 12)
            {
                month = 1;
                year++;
            }
            var dbNotes = _DaysNoteRepository.GetAll().Where(x => x.EventDate.Month == month && x.EventDate.Year == year);
            var dayses = new List<int>();
            switch (new DateTime(year, month, 1).DayOfWeek.ToString())
            {
                case "Monday":
                    break;
                case "Tuesday":
                    dayses.Add(0);
                    break;
                case "Wednesday":
                    dayses.Add(0);
                    dayses.Add(0);
                    break;
                case "Thursday":
                    dayses.Add(0);
                    dayses.Add(0);
                    dayses.Add(0);
                    break;
                case "Friday":
                    dayses.Add(0);
                    dayses.Add(0);
                    dayses.Add(0);
                    dayses.Add(0);
                    break;
                case "Saturday":
                    dayses.Add(0);
                    dayses.Add(0);
                    dayses.Add(0);
                    dayses.Add(0);
                    dayses.Add(0);
                    break;
                case "Sunday":
                    dayses.Add(0);
                    dayses.Add(0);
                    dayses.Add(0);
                    dayses.Add(0);
                    dayses.Add(0);
                    dayses.Add(0);
                    break;
                default:
                    break;
            }
            for (int i = 1; i <= DateTime.DaysInMonth(year, month); i++)
            {
                dayses.Add(i);
            }
            var model = new TestCalendarViewModel()
            {
                Month = month,
                Year = year,
                Days = dayses,
                Notes = dbNotes.Select(x => new TestNotesViewModel()
                {
                    Text = x.Text,
                    EventDate = x.EventDate,
                }).OrderBy(x=>x.EventDate).ToList(),
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult AddNote()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNote(TestNotesViewModel viewModel, int year, int month, int day)
        {
            var dbNote = new DaysNote()
            {
                Text = viewModel.Text,
                EventDate = viewModel.EventDate,
            };
            _DaysNoteRepository.Save(dbNote);
            return RedirectToAction("WatchCurrentNotes", new {year = dbNote.EventDate.Year, month = dbNote.EventDate.Month,
            day = dbNote.EventDate.Day});
        }
        public IActionResult WatchAllNotes()
        {
            var dbNotes = _DaysNoteRepository.GetAll().Where(x=>x.Text != null);
            var model = new TestCalendarViewModel()
            {
                Notes = dbNotes.Select(x => new TestNotesViewModel()
                {
                    Text = x.Text,
                    EventDate = x.EventDate,
                }).ToList(),
            };
            return View(model);
        }
        public IActionResult WatchCurrentNotes(int year, int month, int day)
        {
            var dbNotes = _DaysNoteRepository.GetAll().Where(x => x.EventDate.Year == year && x.EventDate.Month == month
                && x.EventDate.Day == day);
            var model = new TestCalendarViewModel()
            {
                Notes = dbNotes.Select(x => new TestNotesViewModel()
                {
                    Text = x.Text,
                    EventDate = x.EventDate,
                }).ToList(),
            };
            return View(model);
        }

    }
}
