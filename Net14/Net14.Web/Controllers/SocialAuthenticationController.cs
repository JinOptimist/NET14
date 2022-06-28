using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff;
using Net14.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.Repositories;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using AutoMapper;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Microsoft.AspNetCore.SignalR;
using Net14.Web.SignalRHubs;
using Microsoft.IdentityModel.Tokens;
using Net14.Web.Auth;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Logging;
using System.Text;
using Net14.Web.Models.SocialModels;
using Net14.Web.Services;

namespace Net14.Web.Controllers
{
    public class SocialAuthenticationController : Controller

    {
        private IHubContext<ChatHub> _chatHub;
        private SocialUserRepository _socialUserRepository;
        private IMapper _mapper;
        private TokenService _tokenService; 

        public SocialAuthenticationController(SocialUserRepository socialUserRepository, 
            IMapper mapper, 
            IHubContext<ChatHub> chatHub,
            TokenService tokenService)
        {
            _mapper = mapper;
            _socialUserRepository = socialUserRepository;
            _chatHub = chatHub;
            _tokenService = tokenService;
        }


        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(SocialUserRegistrationViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userDb = _mapper.Map<UserSocial>(user);
                userDb.Role = SiteRole.User;
                _socialUserRepository.Save(userDb);

                var claims = new List<Claim>() {
                    new Claim("Id", userDb.Id.ToString()),
                    new Claim("Role", userDb.Role.ToString()),
                    new Claim("Name", userDb.FirstName),
                    new Claim(ClaimTypes.AuthenticationMethod, Startup.AuthName)
                };


                var identity = new ClaimsIdentity(claims, Startup.AuthName);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                return RedirectToRoute("default", new { controller = "Social", action = "MyProfile" });
            }
            else
            {
                return View();

            }
        }
        [HttpGet]
        public IActionResult Autorization(string ReturnUrl)
        {
            var model = new SocialUserAutorizationViewModel()
            {
                ReturnUrl = ReturnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Autorization(SocialUserAutorizationViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userViewModel);
            }

            var user = _socialUserRepository.GetByEmAndPass(userViewModel.Email, userViewModel.Password);

            if (user == null)
            {
                ModelState.AddModelError(nameof(SocialUserAutorizationViewModel.Email), "Invalid email or password");
                return View(userViewModel);
            }

            if (user.IsBlocked == true)
            {
                ModelState.AddModelError(nameof(SocialUserAutorizationViewModel.Email), "This user is blocked");
                return View(userViewModel);
            }

            //good

            var claims = new List<Claim>() {
                new Claim("Id", user.Id.ToString()),
                new Claim("Name", user.FirstName),
                new Claim(ClaimTypes.AuthenticationMethod, Startup.AuthName)
            };

            var identity = new ClaimsIdentity(claims, Startup.AuthName);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);

            await _chatHub
                .Clients
                .All
                .SendAsync("AddMessage", 
                    $"User {user.FirstName} loggined", 
                    "SYSTEM");

            if (userViewModel.ReturnUrl == null)
            {
                return RedirectToRoute("default", new { controller = "Social", action = "MyProfile"});
            }
            return Redirect(userViewModel.ReturnUrl);
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToRoute("default", new { controller = "Social", action = "Index" });
        }

        [HttpPost("/token")]
        public IActionResult Token([FromBody] SocialUserAutorizationViewModel model)
        {
            var identity = _tokenService.GetIdentity(model.Email, model.Password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var encodedJwt = _tokenService.GenerateAccessToken(identity);
            var refreshToken = _tokenService.GenerateRefreshToken();

            var result = new LoginResultViewModel()
            {
                AccessToken = encodedJwt,
                UserName = identity.Name,
                RefreshToken = refreshToken
            };


            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Test() 
        {
            var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");

            return Json(accessToken);
        }
    }
}
