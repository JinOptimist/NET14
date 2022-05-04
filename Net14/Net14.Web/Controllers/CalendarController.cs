using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Net14.Web.Controllers.AutorizeAttribute;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.DbModel.CalendarDbModels;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models;
using Net14.Web.Models.Calendar;
using Net14.Web.Models.Calendar.Test;
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
        private CalendarUsersRepository _CalendarUsersRepository;

        public CalendarController(DaysNoteRepository daysNoteRepository, CalendarUsersRepository calendarUsersRepository)
        {
            _DaysNoteRepository = daysNoteRepository;
            _CalendarUsersRepository = calendarUsersRepository;
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

            var dbNotes = _DaysNoteRepository.GetAll()
                .Where(x => x.EventDate.Month == month && x.EventDate.Year == year
                 && x.CalendarUser == _CalendarUsersRepository.GetAll()
                .FirstOrDefault(x => User.Identity.IsAuthenticated == true) &&
                x.UserName == _CalendarUsersRepository.Get(_CalendarUsersRepository.GetAll()
                .FirstOrDefault(x => User.Identity.IsAuthenticated == true).Id).Name);

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
        [CalendarRole(Roles.User)]
        public IActionResult AddNote()
        {
            return View();
        }
        [HttpPost]
        [CalendarRole(Roles.User)]
        public IActionResult AddNote(TestNotesViewModel viewModel, int year, int month, int day)
        {
            var dbNote = new DaysNote()
            {
                Text = viewModel.Text,
                EventDate = viewModel.EventDate,
                CalendarUser = _CalendarUsersRepository.GetAll()
                .FirstOrDefault(x => User.Identity.IsAuthenticated == true),
                UserName = _CalendarUsersRepository.Get(_CalendarUsersRepository.GetAll()
                .FirstOrDefault(x => User.Identity.IsAuthenticated == true).Id).Name
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
            return RedirectToAction("TestCalendar");
        }
        
        [CalendarRole(Roles.Admin)]
        public IActionResult WatchAllNotes()
        {
            var dbNotes = _DaysNoteRepository.GetAll().Where(x=>x.Text != null && x.CalendarUser ==
            _CalendarUsersRepository.GetAll()
                .FirstOrDefault(x => User.Identity.IsAuthenticated == true));
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
            _CalendarUsersRepository.GetAll()
                .FirstOrDefault(x => User.Identity.IsAuthenticated == true)&&
                x.UserName == _CalendarUsersRepository.Get(_CalendarUsersRepository.GetAll()
                .FirstOrDefault(x => User.Identity.IsAuthenticated == true).Id).Name);
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
            _CalendarUsersRepository.GetAll()
                .FirstOrDefault(x => User.Identity.IsAuthenticated == true) &&
                x.UserName == _CalendarUsersRepository.Get(_CalendarUsersRepository.GetAll()
                .FirstOrDefault(x => User.Identity.IsAuthenticated == true).Id).Name);
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
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(TestCalendarUserRegistration user)
        {
            if (ModelState.IsValid)
            {
                var userdb = new CalendarUser()
                {
                    Name = user.Name,
                    Password = user.Password,
                    Email = user.Email,
                };
                _CalendarUsersRepository.Save(userdb);

                return RedirectToRoute("default", new { controller = "Calendar", action = "TestCalendar", id = userdb.Id });
            }
            else
            {
                return View();

            }
        }
        [HttpGet]
        public IActionResult Autorization()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Autorization(TestCalendarUserAutorization userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = _CalendarUsersRepository.GetByNameAndPass(userViewModel.Name, userViewModel.Password);

            if (user == null)
            {
                return View();
            }

            var claims = new List<Claim>() {
                new Claim("Id", user.Id.ToString()),
                new Claim("Name", user.Name),
                new Claim(ClaimTypes.AuthenticationMethod, Startup.AuthName)
            };

            var identity = new ClaimsIdentity(claims, Startup.AuthName);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);

            return RedirectToRoute("default", new { controller = "Calendar", action = "TestCalendar", id = user.Id });
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(Startup.AuthName);
            return RedirectToRoute("default", new { controller = "Calendar", action = "Index" });
        }

    }
}
