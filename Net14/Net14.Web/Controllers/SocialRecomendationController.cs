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
        public SocialRecomendationController(RecomendationsService recomendationsService,
            SocialGroupRepository socialGroupRepository, IMapper mapper) 
        {
            _mapper = mapper;
            _socialGroupRepository = socialGroupRepository;
            _recomendationsService = recomendationsService;
        }
        public IActionResult Recomendations() 
        {
            var recomendationUsersViewModel = _recomendationsService.GetUserRecomendation();
            return View(recomendationUsersViewModel);
        }
        public IActionResult GroupRecomendations()
        {
            var recomendationGroup = _socialGroupRepository.GetAll();
            var viewModel = _mapper.Map<List<SocialGroupViewModel>>(recomendationGroup);

            return View(viewModel);
        }
    }
}
