using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.SocialModels
{
    public class SocialChangeAvatarViewMode
    {
        public IFormFile NewPhoto { get; set; }
    }
}
