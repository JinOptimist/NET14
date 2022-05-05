using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class UserDialogViewModel
    {
        public SocialUserViewModel CurrentUser { get; set; }
        public SocialUserViewModel User { get; set; }
        public SocialMessageViewModel LastMessage { get; set; }

    }
}