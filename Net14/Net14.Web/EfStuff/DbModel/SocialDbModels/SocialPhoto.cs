using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using TeamSocial;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class SocialPhoto : BaseModel
    {
        public virtual UserSocial Owner { get; set; }
        public string Url { get; set; }

    }
}