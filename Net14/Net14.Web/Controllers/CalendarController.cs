using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Net14.Web.Controllers.AutorizeAttribute;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models;
using Net14.Web.Models.Calendar;
using Net14.Web.Models.Calendar.Test;
using Net14.Web.Services;
using Net14.Web.SignalRHubs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Net14.Web.Controllers
{
    public class CalendarController : Controller
    {
        private DaysNoteRepository _DaysNoteRepository;
        private SocialUserRepository _SocialUserRepository;
        private UserService _UserService;
        private IMapper _mapper;
        private IHubContext<ChatHub> _chatHub;
        public CalendarController(DaysNoteRepository daysNoteRepository, SocialUserRepository socialUserRepository,
            UserService userService, IMapper mapper, IHubContext<ChatHub> chatHub)
        {
            _DaysNoteRepository = daysNoteRepository;
            _SocialUserRepository = socialUserRepository;
            _UserService = userService;
            _mapper = mapper;
            _chatHub = chatHub;
        }

        public IActionResult Index()
        {
            return View(_UserService);
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

            var dbNotes = _DaysNoteRepository.GetAll()
                .Where(x=>x.EventDate.Month == month && x.EventDate.Year == year 
                && x.CalendarUser == _UserService.GetCurrent());

            var dayses = new List<int>();
            int prevMonthDays = DateTime.DaysInMonth(year, month - 1);
            switch (new DateTime(year, month, 1).DayOfWeek.ToString())
            {
                case "Monday":
                    break;
                case "Tuesday":
                    dayses.Add(prevMonthDays);
                    break;
                case "Wednesday":
                    dayses.Add(prevMonthDays-1);
                    dayses.Add(prevMonthDays);
                    break;
                case "Thursday":
                    dayses.Add(prevMonthDays - 2);
                    dayses.Add(prevMonthDays - 1);
                    dayses.Add(prevMonthDays);
                    break;
                case "Friday":
                    dayses.Add(prevMonthDays - 3);
                    dayses.Add(prevMonthDays - 2);
                    dayses.Add(prevMonthDays - 1);
                    dayses.Add(prevMonthDays);
                    break;
                case "Saturday":
                    dayses.Add(prevMonthDays-4);
                    dayses.Add(prevMonthDays-3);
                    dayses.Add(prevMonthDays-2);
                    dayses.Add(prevMonthDays-1);
                    dayses.Add(prevMonthDays);
                    break;
                case "Sunday":
                    dayses.Add(prevMonthDays-5);
                    dayses.Add(prevMonthDays-4);
                    dayses.Add(prevMonthDays-3);
                    dayses.Add(prevMonthDays-2);
                    dayses.Add(prevMonthDays-1);
                    dayses.Add(prevMonthDays);
                    break;
                default:
                    break;
            }
            for (int i = 1; i <= DateTime.DaysInMonth(year, month); i++)
            {
                dayses.Add(i);
            }
            if (User.Identity.IsAuthenticated)
            {
                var model = new TestCalendarViewModel()
                {
                    Month = month,
                    Year = year,
                    Days = dayses,
                    Notes = dbNotes.Select(x => new TestNotesViewModel()
                    {
                        Text = x.Text,
                        EventDate = x.EventDate,
                        CalendarUser = x.CalendarUser,
                    }).OrderBy(x => x.EventDate).ToList(),
                };
                return View(model);
            }
            else
            {
                var model = new TestCalendarViewModel()
                {
                    Month = month,
                    Year = year,
                    Days = dayses,
                };
                return View(model);
            }
            
            
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
                CalendarUser = _UserService.GetCurrent()
            };
            _DaysNoteRepository.Save(dbNote);
            return RedirectToAction("WatchCurrentNotes", new {year = dbNote.EventDate.Year, month = dbNote.EventDate.Month,
            day = dbNote.EventDate.Day});
        }
        public IActionResult RemoveNote(string text, int year, int month, int day)
        {
            var dbNote = _DaysNoteRepository.GetAll()
                .FirstOrDefault(x => x.Text == text&&
                x.EventDate.Year == year && 
                x.EventDate.Month == month && 
                x.EventDate.Day == day);
            _DaysNoteRepository.Remove(dbNote);
            return RedirectToAction("TestCalendar", new { year = dbNote.EventDate.Year, month = dbNote.EventDate.Month });
        }
        
        public IActionResult WatchAllNotes()
        {
            var dbNotes = _DaysNoteRepository.GetAll().Where(x=>x.Text != null && x.CalendarUser ==
            _UserService.GetCurrent());
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
            var dbNotes = _DaysNoteRepository.GetAll()
                .Where(x => x.EventDate.Year == year && x.EventDate.Month == month
                && x.EventDate.Day == day)
                .Where(x => x.Text != null && x.CalendarUser ==
            _UserService.GetCurrent());
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
        public IActionResult ViewCurrentNotes(int year, int month, int day)
        {
            var dbNotes = _DaysNoteRepository.GetAll()
                .Where(x => x.EventDate.Year == year && x.EventDate.Month == month
                && x.EventDate.Day == day)
                .Where(x => x.Text != null && x.CalendarUser ==
            _UserService.GetCurrent());
            var model = new TestCalendarViewModel()
            {
                Notes = dbNotes.Select(x => new TestNotesViewModel()
                {
                    Text = x.Text,
                }).ToList(),
            };
            List<string> model1 = new List<string>();
            foreach (var item in dbNotes)
                model1.Add(item.Text);
            return Json(model1);
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(Startup.AuthName);
            return RedirectToRoute("default", new { controller = "Calendar", action = "Index" });
        }

    }
}
