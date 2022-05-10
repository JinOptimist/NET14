using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.Models.SocialModels.Enums;

namespace Net14.Web.Models
{
    public class UserDialogViewModel
    {
        public SocialUserViewModel CurrentUser { get; set; }
        public SocialUserViewModel User { get; set; }
        public SocialMessageViewModel LastMessage { get; set; }
        public MessageType LastMessageType { get; set; }

    }
}