using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class SocialPostViewModel
    {
        public int UserId { get; set; }
        public string ImageUrl { get; set; } = "ImageUrl";
        public string Comments { get; set; }
        public string TypePost { get; set; } = "Registartion";
        public int Likes { get; set; } = 0;

    }
}
