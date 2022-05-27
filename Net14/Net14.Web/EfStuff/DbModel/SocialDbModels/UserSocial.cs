using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSocial;


namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class UserSocial : BaseModel
    {
        public string UserPhoto { get; set; } = "/images/Social/User.jpg";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsBlocked { get; set; }
        public SiteRole Role { get; set; }
        public Language Language { get; set; }
        public virtual List<FileSocial> Files { get; set; }
        public virtual List<PostSocial> Posts { get; set; }
        public virtual List<GroupSocial> Groups { get; set; }
        public virtual List<UserSocial> Friends { get; set; } = new List<UserSocial>();
        public virtual List<UserSocial> WhoFriends { get; set; } = new List<UserSocial>();
        public virtual List<UserFriendRequest> FriendRequestSent { get; set; } = new List<UserFriendRequest>();
        public virtual List<UserFriendRequest> FriendRequestReceived { get; set; } = new List<UserFriendRequest>();
        public virtual Basket Basket { get; set; }
        public virtual List<SocialMessages> SendMessages { get; set; } = new List<SocialMessages>();
        public virtual List<SocialMessages> RecievedMessages { get; set; } = new List<SocialMessages>();
        
    }
}
