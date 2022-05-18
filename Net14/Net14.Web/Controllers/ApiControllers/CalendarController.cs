using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
      
    }
}
