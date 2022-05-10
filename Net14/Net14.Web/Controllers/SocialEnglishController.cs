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

namespace Net14.Web.Controllers
{
    public class SocialEnglishController : Controller

    {
        private IMapper _mapper;

        public SocialEnglishController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult WordsEnglish()
        {
            return View();
        }
        public IActionResult Animation()
        {
            return View();
        }
    }
}
