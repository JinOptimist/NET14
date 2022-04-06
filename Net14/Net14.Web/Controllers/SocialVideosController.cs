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
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Text.Json;
using Net14.Web.Services;
using Microsoft.AspNetCore.Authorization;


namespace Net14.Web.Controllers
{
    public class SocialVideosController : Controller
    {
        private VideoSocialRepository _videoSocialRepository;
        private YouTubeVideoGetter _youTubeVideoGetter;
        private const string chaneId = "UCJC0-trcxlfV8uuygkbFDHg";

        public SocialVideosController(VideoSocialRepository videoSocial, YouTubeVideoGetter youTubeVideoGetter) 
        {

            _videoSocialRepository = videoSocial;
            _youTubeVideoGetter = youTubeVideoGetter;
        }

        [Authorize]
        public IActionResult GetVideos(int page = 1) 
        {
            const int perPage = 4;
            var res = _youTubeVideoGetter.GetVideos(page, perPage, chaneId).ToList();
            var model = new SocialPageVideoViewModel()
            {
                Videos = res,
                Page = page,
            };
            return View(model);
        }
    }
}
