using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class SocialPostViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ImageUrl { get; set; } = "ImageUrl";
        public string NameOfUser { get; set; }
        public string CommentsOfOwner { get; set; }
        public string TypePost { get; set; } = "Registartion";
        public int Likes { get; set; } = 0;
        public string UserPhotoUrl { get; set; }
        public List<string> Comments { get; set; } = new List<string>();

    }
}
