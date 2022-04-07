using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSocial;
using Net14.Web.Models;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class SocialCommentViewModel {
        
        public virtual SocialUserViewModel User { get; set; }
        public string Text { get; set; }
        public DateTime DateOfPosting { get; set; }
    }
}
