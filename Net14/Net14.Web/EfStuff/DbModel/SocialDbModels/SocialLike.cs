using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using TeamSocial;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class SocialLike : BaseModel
    {
        public virtual UserSocial User { get; set; }
        public virtual PostSocial Post { get; set; }

    }
}