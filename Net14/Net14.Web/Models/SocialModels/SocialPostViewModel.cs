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
        public string UserName { get; set; }
        public string CommentOfUser { get; set; }
        public string TypePost { get; set; } = "Registartion";
        public int Likes { get; set; } = 0;
        public string UserPhoto { get; set; }
        public bool IsLikedCurrentUser { get; set; } = false;
        public List<SocialCommentViewModel> Comments { get; set; } = new List<SocialCommentViewModel>();

    }
}
