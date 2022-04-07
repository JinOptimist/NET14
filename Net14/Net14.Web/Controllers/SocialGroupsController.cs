using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using AutoMapper;

namespace Net14.Web.Controllers
{
    public class SocialGroupsController : Controller
    {
        private SocialGroupRepository _socialGroupRepository;
        private IMapper _mapper;
        public SocialGroupsController(SocialGroupRepository socialGroupRepository, IMapper mapper) 
        {
            _mapper = mapper;
            _socialGroupRepository = socialGroupRepository;
        }
        public IActionResult GetGroups()
        {
            var groupArray = _socialGroupRepository.GetAll();
            var model = _mapper.Map<List<SocialGroupViewModel>>(groupArray);
            
            return View(model);
        }

        public IActionResult GetSingleGroup(int id) 
        {
            var group = _socialGroupRepository.Get(id);
            var model = _mapper.Map<SocialGroupViewModel>(group);

            return View(model);
        }
    }
}
