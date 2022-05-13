using Microsoft.AspNetCore.Mvc;
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
using Net14.Web.Services;
using AutoMapper;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Net14.Web.Controllers.AutorizeAttribute;
using Microsoft.AspNetCore.SignalR;
using Net14.Web.SignalRHubs;

namespace Net14.Web.Controllers
{
    public class WebSiteController : Controller
    {
        public PersonOnRepository _personOnRepository;

        public WebSiteController(PersonOnRepository personOnRepository)
        {
            _personOnRepository = personOnRepository;
        }

        
        public IActionResult OurTeam(/*int Id*/)
        {
/*
            var dbModel = _personOnRepository.Get(Id);
            var model = new PersonViewModel()
            {
                Name = dbModel.Name,
                Age = dbModel.Age,
                Race = dbModel.Race,
                Url = dbModel.Url,
                Number = dbModel.Number
            };*/
            return View(/*model*/);
        }
        public IActionResult OurProduct()
        {
            return View();
        }
        public IActionResult MainPage()
        {
            return View();
        }
        public IActionResult ДаняГришковец()
        {
            return View();
        }
        public IActionResult КириллПерепечкин()
        {
            return View();
        }
        public IActionResult КсюшаАфонина()
        {
            return View();
        }
        public IActionResult ДанилаМалец()
        {
            return View();
        }
        public IActionResult НастяПоворотная()
        {
            return View();
        }
        public IActionResult КириллАнашкин()
        {
            return View();
        }
        public IActionResult ДианаБасич()
        {
            return View();
        }
        public IActionResult КсенияБорисенко()
        {
            return View();
        }
        public IActionResult АлинаГерасименко()
        {
            return View();
        }
        public IActionResult КаролинаВиноградова()
        {
            return View();
        }
        public IActionResult ПолинаМоисеева()
        {
            return View();
        }
        public IActionResult ДашаСизова()
        {
            return View();
        }
        public IActionResult АннаМачульская()
        {
            return View();
        }
        public IActionResult НикитаСалагуб()
        {
            return View();
        }
        public IActionResult ДашаРокало()
        {
            return View();
        }
        public IActionResult АлинаКрасильникова()
        {
            return View();
        }
        public IActionResult МельтемШахин()
        {
            return View();
        }
        public IActionResult ВикторияСоловей()
        {
            return View();
        }
        public IActionResult ПолинаФедюк()
        {
            return View();
        }
        public IActionResult АндрейЦеховой()
        {
            return View();
        }
        public IActionResult ДаняМинько()
        {
            return View();
        }
        public IActionResult ИльяАкулёнок()
        {
            return View();
        }
        public IActionResult Лу()
        {
            return View();
        }
    }
}
