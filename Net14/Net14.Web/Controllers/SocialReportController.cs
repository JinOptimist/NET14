﻿using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.Repositories;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Net14.Web.Services;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Net14.Web.Controllers.AutorizeAttribute;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Microsoft.AspNetCore.SignalR;
using Net14.Web.SignalRHubs;
using System.Threading;

namespace Net14.Web.Controllers
{ 
    [Authorize]
    public class SocialReportController : Controller

    {
        private static List<Task> ReportTask = new List<Task>();
        private IMapper _mapper;
        private UserService _userService;
        private SocialUserRepository _userRepository;
        private IWebHostEnvironment _webHostEnvironment;
        private ReportsRepository _reportsRepository;
        private ReportsService _reportsService;
        

        public SocialReportController(IMapper mapper, 
            UserService userService,
            SocialUserRepository userRepository,
            IWebHostEnvironment webHostEnvironment,
            ReportsRepository reportsRepository,
            ReportsService reportsService
            )
        {
            _mapper = mapper;
            _userService = userService;
            _userRepository = userRepository;
            _webHostEnvironment = webHostEnvironment;
            _reportsRepository = reportsRepository;
            _reportsService = reportsService;
        }


        public IActionResult ReportsPage() 
        {
            var user = _userService.GetCurrent();

            var reportsViewModels = _mapper.Map<List<SocialReportViewModel>>(user.UsersReports);


            return View(reportsViewModels);
        }
        public IActionResult GetReport(int userId)
        {
            var user = _userRepository.GetUserToReport(userId);
            var userToDb = _userRepository.Get(userId);


            var fileName = $"reportUser{userId}at{DateTime.Today.ToShortDateString()}.docx";

            var path = Path.Combine(
                _webHostEnvironment.WebRootPath,
                "reports",
                fileName);

            var report = new SocialReport()
            {
                UserReport = userToDb,
                CreatingDate = DateTime.Now,
                Url = path,
                Name = fileName
            };

            _reportsRepository.Save(report);

            var reportViewModel = _mapper.Map<SocialReportViewModel>(report);
            var tokenSource = new CancellationTokenSource();

            var reportTask = new Task<bool>(() => _reportsService.GetUserReport(user, path, report.Id), tokenSource.Token);

            lock (ReportTask)
            {
                ReportTask.Add(reportTask);
            }

            reportTask.Start();

            return Json(reportViewModel);

        }

    }
}
