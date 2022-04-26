using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSocial;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class GroupSocial : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public virtual List<PostSocial> Posts { get; set; }
        public virtual List<UserSocial> Members { get; set; }
        public virtual List<GroupTags> Tags { get; set; } 
    }
}