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
        public UserSocial Sender { get; set; }
        public FriendRequestStatus FriendRequestStatus { get; set; }

    }
}