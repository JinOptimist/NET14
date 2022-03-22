using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSocial;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class PostSocial
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ImageUrl { get; set; } = "ImageUrl";
        public string UserComments { get; set; }
        public string TypePost { get; set; } = "Registartion";
        public int Likes { get; set; } = 0;
        public DateTime DateOfPosting { get; set; } = DateTime.Now.ToLocalTime();

    }
}
