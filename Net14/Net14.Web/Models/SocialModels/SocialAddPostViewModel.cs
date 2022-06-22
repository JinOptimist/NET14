using Microsoft.AspNetCore.Http;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class SocialAddPostViewModel
    {
        public string CommentOfUser { get; set; }
        public  IFormFile ImageUrl { get; set; }


    }
}
