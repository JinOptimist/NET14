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
        public virtual List<SocialComment> Comments { get; set; }
        public string TypePost { get; set; } = "Registartion";
        public virtual List<PostLikes> Likes { get; set; }
        public DateTime DateOfPosting { get; set; } = DateTime.Now.ToLocalTime();

    }
}
