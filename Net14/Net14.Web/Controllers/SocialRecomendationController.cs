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

namespace Net14.Web.Controllers
{
    [Authorize]
    public class SocialRecomendationController : Controller
    {
        private RecomendationsService _recomendationsService;
        public SocialRecomendationController(RecomendationsService recomendationsService) 
        {
            _recomendationsService = recomendationsService;
        }
        public IActionResult Recomendation() 
        {
            var recomendationUsersViewModel = _recomendationsService.GetUserRecomendation();
            return View(recomendationUsersViewModel);
        }
    }
}
