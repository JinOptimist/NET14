using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class SocialPostLikeViewModel
    {
        public UserSocial User { get; set; }
        public SocialPostViewModel Post { get; set; }

    }
}
