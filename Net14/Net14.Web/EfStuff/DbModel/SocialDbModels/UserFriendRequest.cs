using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TeamSocial;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class UserFriendRequest : BaseModel
    {

        public int SenderId { get; set; }

        public virtual UserSocial Sender { get; set; }

        public int ReceiverId { get; set; }
        public virtual UserSocial Receiver { get; set; }

        [Required]
        public FriendRequestStatus FriendRequestStatus { get; set; }

    }
}
