using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSocial;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class PostLikes : BaseModel
    {
        public virtual UserSocial Owner { get; set; }
        public virtual PostSocial Post { get; set; }

    }
}
