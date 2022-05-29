using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Net14.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Net14.Web.EfStuff.Repositories;
using AutoMapper;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.Models.SocialModels;

namespace Net14.Web.Controllers
{
    [Authorize]
    public class SocialRecomendationController : Controller
    {
        private RecomendationsService _recomendationsService;
        private SocialGroupRepository _socialGroupRepository;
        private IMapper _mapper;
        private UserService _userService;
        public SocialRecomendationController(RecomendationsService recomendationsService,
            SocialGroupRepository socialGroupRepository, IMapper mapper, UserService userService)
        {
            _mapper = mapper;
            _socialGroupRepository = socialGroupRepository;
            _recomendationsService = recomendationsService;
            _userService = userService;
        }
        public IActionResult Recomendations() 
        {
            var currentUser = _userService.GetCurrent();
            var recomendationUsersViewModel = _recomendationsService.GetUserRecomendation();
            string absoluteurl = HttpContext.Request.Path.Value;
            var model = new SocialUserRecomendationUrlViewModel()
            {
                Recomendations = recomendationUsersViewModel,
                Url = absoluteurl
            };
            model.User = currentUser;

            return View(model);
        }
        public IActionResult GroupRecomendations()
        {
            var currentUser = _userService.GetCurrent();
            var recomendations = _recomendationsService.GetGroupsRecomendation();
            
            return View(recomendations);
        }
    }
}
