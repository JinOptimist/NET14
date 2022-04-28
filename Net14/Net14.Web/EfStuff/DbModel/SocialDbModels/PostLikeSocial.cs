using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSocial;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class PostLikeSocial : BaseModel
    {
        public virtual UserSocial User { get; set; }
        public virtual PostSocial Post { get; set; }

    }
}
