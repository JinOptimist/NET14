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
        public string FirstName { get; set; }
        public string CommentOfUser { get; set; }
        public string TypePost { get; set; } = "Registartion";
        public string UserPhoto { get; set; }
        public int CountLikes { get; set; }
        public List<SocialPostLikeViewModel> Likes { get; set; } = new List<SocialPostLikeViewModel>();
        public List<SocialCommentViewModel> Comments { get; set; } = new List<SocialCommentViewModel>();

    }
}
