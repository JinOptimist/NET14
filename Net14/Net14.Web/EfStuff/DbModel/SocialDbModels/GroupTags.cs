using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSocial;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class GroupTags : BaseModel
    {
        public virtual GroupSocial Group { get; set; }
        public string Tag { get; set; }
    }
}