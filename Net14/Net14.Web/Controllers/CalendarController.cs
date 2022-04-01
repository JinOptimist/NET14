using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models;
using Net14.Web.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Controllers
{
    public class CalendarController : Controller
    {
        private DaysRepository _daysRepository;
        private DaysNoteRepository _DaysNoteRepository;

        public CalendarController(DaysNoteRepository daysNoteRepository, DaysRepository daysRepository)
        {
            _DaysNoteRepository = daysNoteRepository;
            _daysRepository = daysRepository;
        }

        public IActionResult Index()
        {
            
            return View();
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
                case "Week":
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

            return View(dbNote);
        }
    }
}
