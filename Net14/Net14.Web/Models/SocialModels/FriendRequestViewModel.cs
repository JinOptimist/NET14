using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;

namespace Net14.Web.Models
{
    public class FriendRequestViewModel
    {
        public SocialUserViewModel Sender { get; set; }
        public FriendRequestStatus FriendRequestStatus { get; set; }
        public SocialUserViewModel Receiver { get; set; }
        public RequestViewModelType Type { get; set; }

    }
}