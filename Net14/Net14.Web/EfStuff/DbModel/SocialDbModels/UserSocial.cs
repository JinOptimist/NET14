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
        public virtual List<PostSocial> Posts { get; set; }
    }
}
