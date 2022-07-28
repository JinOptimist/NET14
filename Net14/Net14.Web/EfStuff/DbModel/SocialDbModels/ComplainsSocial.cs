using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using TeamSocial;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class ComplainsSocial : BaseModel
    {
        public virtual PostSocial Post { get; set; }
        public virtual UserSocial OwnerOfComplain { get; set; }
        public string ReasonOfComplain { get; set; }
    }
}