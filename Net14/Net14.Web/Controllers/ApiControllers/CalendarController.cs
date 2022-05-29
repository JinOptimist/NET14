using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models.Calendar;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private IWebHostEnvironment _webHostEnvironment;
        private DaysNoteRepository _daysNoteRepository;
        private UserService _userService;

        public CalendarController(IWebHostEnvironment webHostEnvironment,
            DaysNoteRepository daysNoteRepository, UserService userService)
        {
            _webHostEnvironment = webHostEnvironment;
            _daysNoteRepository = daysNoteRepository;
            _userService = userService;
        }
        
        public List<int> GetAllViewDays(int year, int month)
        {
            List<int> days = new List<int>();
            DayOfWeek currrentMonthFirstDay = new DateTime(year, month, 1).DayOfWeek;
            if (month <= 1)
            {
                month = 12;
                year--;
            }
            var daysInPrevMonth = DateTime.DaysInMonth(year, month - 1);
            switch (currrentMonthFirstDay)
            {
                case DayOfWeek.Monday:
                    break;
                case DayOfWeek.Tuesday:
                    days.Add(daysInPrevMonth);
                    break;
                case DayOfWeek.Wednesday:
                    days.Add(daysInPrevMonth - 1);
                    days.Add(daysInPrevMonth);
                    break;
                case DayOfWeek.Thursday:
                    days.Add(daysInPrevMonth - 2);
                    days.Add(daysInPrevMonth - 1);
                    days.Add(daysInPrevMonth);
                    break;
                case DayOfWeek.Friday:
                    days.Add(daysInPrevMonth - 3);
                    days.Add(daysInPrevMonth - 2);
                    days.Add(daysInPrevMonth - 1);
                    days.Add(daysInPrevMonth);
                    break;
                case DayOfWeek.Saturday:
                    days.Add(daysInPrevMonth - 4);
                    days.Add(daysInPrevMonth - 3);
                    days.Add(daysInPrevMonth - 2);
                    days.Add(daysInPrevMonth - 1);
                    days.Add(daysInPrevMonth);
                    break;
                case DayOfWeek.Sunday:
                    days.Add(daysInPrevMonth - 5);
                    days.Add(daysInPrevMonth - 4);
                    days.Add(daysInPrevMonth - 3);
                    days.Add(daysInPrevMonth - 2);
                    days.Add(daysInPrevMonth - 1);
                    days.Add(daysInPrevMonth);
                    break;
            }
            var daysInCurrentMonth = DateTime.DaysInMonth(year, month);
            for (int i = 1; i <= daysInCurrentMonth; i++)
            {
                days.Add(i);
            }
            if (month >= 12)
            {
                month = 1;
                year++;
            }
            DayOfWeek nextMonthFirstDay = new DateTime(year, month+1, 1).DayOfWeek;
            switch (nextMonthFirstDay)
            {
                case DayOfWeek.Monday:
                    days.Add(1);
                    days.Add(2);
                    days.Add(3);
                    days.Add(4);
                    days.Add(5);
                    days.Add(6);
                    days.Add(7);
                    break;
                case DayOfWeek.Tuesday:
                    days.Add(1);
                    days.Add(2);
                    days.Add(3);
                    days.Add(4);
                    days.Add(5);
                    days.Add(6);
                    break;
                case DayOfWeek.Wednesday:
                    days.Add(1);
                    days.Add(2);
                    days.Add(3);
                    days.Add(4);
                    days.Add(5);
                    break;
                case DayOfWeek.Thursday:
                    days.Add(1);
                    days.Add(2);
                    days.Add(3);
                    days.Add(4);
                    break;
                case DayOfWeek.Friday:
                    days.Add(1);
                    days.Add(2);
                    days.Add(3);
                    break;
                case DayOfWeek.Saturday:
                    days.Add(1);
                    days.Add(2);
                    break;
                case DayOfWeek.Sunday:
                    days.Add(1);
                    break;
            }
            return days;
        }
        public List<TestNotesViewModel> MonthNotes(int year, int month)
        {
            List<TestNotesViewModel> monthNotes = new List<TestNotesViewModel>();
            var dbNotes = _daysNoteRepository
                .GetAll()
                .Where(n => n.EventDate.Month == month && n.EventDate.Year == year)
                .Where(n => n.CalendarUser == _userService.GetCurrent() || n.CalendarUser.Role == SiteRole.CalendarAdmin)
                .ToList();
            foreach (var note in dbNotes)
            {
                monthNotes.Add(new TestNotesViewModel
                {
                    Text = note.Text,
                    EventDate = note.EventDate,
                    IsImportent = note.IsImportent,
                });
            }
            monthNotes.Sort((x, y) => DateTime.Compare(x.EventDate, y.EventDate));
            return monthNotes;
        }
        public void AddNote(string text, int day, bool isImportant)
        {
            var note = new DaysNote
            {
                Text = text,
                EventDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day),
                IsImportent = isImportant,
                CalendarUser = _userService.GetCurrent(),
                CreatedDate = DateTime.Now,
            };
            _daysNoteRepository.Save(note);
        }
        public void DeleteNote(string text, int day, int year, int month)
        {
            var note = _daysNoteRepository
                .GetAll()
                .Where(n => n.Text == text && n.EventDate.Day == day && n.EventDate.Month == month && n.EventDate.Year == year)
                .FirstOrDefault();
            _daysNoteRepository.Remove(note);
        }
        
    }
}
