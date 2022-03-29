using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSocial;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class SocialCommentViewModel {
        
        public virtual UserSocial User { get; set; }
        public string Text { get; set; }
        public DateTime DateOfPosting { get; set; }
    }
}
