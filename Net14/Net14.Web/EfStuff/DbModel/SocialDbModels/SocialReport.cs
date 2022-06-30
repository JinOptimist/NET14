using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using TeamSocial;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class SocialReport : BaseModel
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public DateTime CreatingDate { get; set; }
        public virtual UserSocial UserReport { get; set; }
        public bool IsCompleted { get; set; }

    }
}