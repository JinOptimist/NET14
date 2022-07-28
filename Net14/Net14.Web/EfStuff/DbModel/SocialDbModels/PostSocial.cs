using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSocial;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class PostSocial : BaseModel
    {
        public virtual UserSocial User { get; set; }
        public string ImageUrl { get; set; } = "ImageUrl";
        public string CommentOfUser { get; set; }
        public virtual List<SocialComment> Comments { get; set; } = new List<SocialComment>();
        public string TypePost { get; set; } = "Registartion";
        public virtual List<SocialLike> Likes { get; set; } = new List<SocialLike>();
        public DateTime DateOfPosting { get; set; } = DateTime.Now.ToLocalTime();
        public virtual List<ComplainsSocial> Complains { get; set; } = new List<ComplainsSocial>();
        public bool IsCheckedForComplains { get; set; }

    }
}
