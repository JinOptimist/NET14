using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using AutoMapper;
using Net14.Web.Services;
using Net14.Web.EfStuff;
using Microsoft.AspNetCore.Authorization;

namespace Net14.Web.Controllers
{
    public class SocialGroupsController : Controller
    {
        private SocialGroupRepository _socialGroupRepository;
        private IMapper _mapper;
        private UserService _userService;
        private WebContext _webContext;
        public SocialGroupsController(SocialGroupRepository socialGroupRepository, 
            IMapper mapper, UserService userService, WebContext webContext) 
        {
            _mapper = mapper;
            _socialGroupRepository = socialGroupRepository;
            _userService = userService;
            _webContext = webContext;
        }
        public IActionResult GetGroups()
        {
            var groupArray = _socialGroupRepository.GetAll();
            var model = _mapper.Map<List<SocialGroupViewModel>>(groupArray);
            
            return View(model);
        }

        [HttpPost]
        public IActionResult GetGroups(string name) 
        {
            var model = _mapper.Map<List<SocialGroupViewModel>>(_socialGroupRepository.GetGroupsByName(name));

            return View(model);
        }

        public IActionResult GetSingleGroup(int id) 
        {
            var group = _socialGroupRepository.Get(id);
            var model = _mapper.Map<SocialGroupViewModel>(group);
            var currentUser = _userService.GetCurrent();
            if (group.Members.Contains(currentUser))
            {
                model.IsCurUserIsMember = true;
            }
            else 
            {
                model.IsCurUserIsMember = false;
            }
            return View(model);
        }

        [Authorize]
        public IActionResult Subscribe(int groupId) 
        {
            var user = _userService.GetCurrent();
            var groupTarget = _socialGroupRepository.Get(groupId);
            user.Groups.Add(groupTarget);
            groupTarget.Members.Add(user);
            _webContext.SaveChanges();
            return Redirect($"/SocialGroups/GetSingleGroup?id={groupId}");
        }

        [Authorize]
        public IActionResult Unsubscribe(int groupId) 
        {
            var user = _userService.GetCurrent();
            _socialGroupRepository.RemoveMember(groupId, user.Id);

            return Redirect($"/SocialGroups/GetSingleGroup?id={groupId}");
        }
    }
}
