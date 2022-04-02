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
            };
            return View(model);
        }
        public IActionResult WatchCalendar(int month = 4, int year = 2022)
        {
            List<CalendarViewModel> model = new List<CalendarViewModel>();
            void addEmptyDay()
            {
                model.Add(new CalendarViewModel()
                {
                    Day = 0,
                    Month = month,
                    Year = year,
                    Color = ConsoleColor.White,
                });
            }
            switch (new DateTime(year,month,1).DayOfWeek.ToString())
            {
                case "Monday":
                    break;
                case "Tuesday":
                    addEmptyDay();
                    break;
                case "Wednesday":
                    addEmptyDay();
                    addEmptyDay();
                    break;
                case "Thursday":
                    addEmptyDay();
                    addEmptyDay();
                    addEmptyDay();
                    break;
                case "Friday":
                    addEmptyDay();
                    addEmptyDay();
                    addEmptyDay();
                    addEmptyDay();
                    break;
                case "Saturday":
                    addEmptyDay();
                    addEmptyDay();
                    addEmptyDay();
                    addEmptyDay();
                    addEmptyDay();
                    break;
                case "Sunday":
                    addEmptyDay();
                    addEmptyDay();
                    addEmptyDay();
                    addEmptyDay();
                    addEmptyDay();
                    addEmptyDay();
                    break;
                default:
                    break;
            }
            for (int i = 1; i <= DateTime.DaysInMonth(year,month); i++)
            {
                if (new DateTime(year, month, i).DayOfWeek.ToString() == "Sunday"
                    || new DateTime(year, month, i).DayOfWeek.ToString() == "Saturday")
                {
                    model.Add(new CalendarViewModel()
                    {
                        Day = i,
                        Month = month,
                        Year = year,
                        DOW = new DateTime(year, month, i).DayOfWeek.ToString(),
                        IsHoliday = true,
                        Color = ConsoleColor.Red,
                    });
                } 
                else
                {
                    model.Add(new CalendarViewModel()
                    {
                        Day = i,
                        Month = month,
                        Year = year,
                        DOW = new DateTime(year, month, i).DayOfWeek.ToString(),
                        IsHoliday = false,
                        Color = ConsoleColor.White,
                    });
                }
            }
            return View(model);
        }
        public IActionResult CurrentMonth()
        {
            var Month = DateTime.Now.Month;
            var Year = DateTime.Now.Year;
            return RedirectToAction("WatchCalendar", new { month = Month, year = Year });
        }
        public IActionResult NextMonth(int month, int year)
        {
            
            return RedirectToAction("WatchCalendar", new { month, year });
        }
        public IActionResult PreviousMonth(int month, int year)
        {
            
            return RedirectToAction("WatchCalendar", new { month,year });
        }
        [HttpGet]
        public IActionResult AddNote()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNote(NotesViewModel viewModel)
        {
            var dbNote = new DaysNote()
            {
                Text = viewModel.Text,
                EventDate = viewModel.EventDate,
            };
            _DaysNoteRepository.Save(dbNote);
            return View();
        }
    }
}
