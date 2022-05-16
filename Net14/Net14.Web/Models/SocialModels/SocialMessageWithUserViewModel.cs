using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.Models.SocialModels.Enums;

namespace Net14.Web.Models
{
    public class SocialMessageWithUserViewModel
    {
        public List<SocialMessageViewModel> Messages { get; set; }
        public SocialUserViewModel UserOfDialog { get; set; }
        
        public SocialMessageViewModel SendMessage { get; set; }

    }
}