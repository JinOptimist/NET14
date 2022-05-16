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

namespace Net14.Web.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SocialGroupsController : ControllerBase
    {
        private SocialGroupRepository _socialGroupRepository;
        private UserService _userService;
        public SocialGroupsController(SocialGroupRepository socialGroupRepository, 
             UserService userService) 
        {
            _socialGroupRepository = socialGroupRepository;
            _userService = userService;
        }


        [Authorize]
        public IActionResult Subscribe(int groupId) 
        {
            var user = _userService.GetCurrent();
            _socialGroupRepository.Subscribe(groupId, user.Id);
            return Ok();

        }

        [Authorize]
        public IActionResult Unsubscribe(int groupId) 
        {
            var user = _userService.GetCurrent();
            _socialGroupRepository.Unsubscribe(groupId, user.Id);
            return Ok();
        }
    }
}
