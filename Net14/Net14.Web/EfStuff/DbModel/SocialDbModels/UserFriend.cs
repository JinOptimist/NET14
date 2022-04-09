using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSocial;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class UserFriend : BaseModel
    {

        public int UserId { get; set; }
        public virtual UserSocial User { get; set; }
        public int FriendId { get; set; }
        public virtual UserSocial Friend { get; set; }
    }
}