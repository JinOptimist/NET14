using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class SocialUserViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public byte[] Salt { get; set; }
        public DateTime DateOfRegistration { get; } = DateTime.Now.ToLocalTime();

        //public Wall wallOfUser = new Wall();
        //public List<User> friends { get; set; } = new List<User>();

        //public FriendsWall wallOffriends;
        //   public PostWall wallpost;
        //public Social social { get; set; } //Теперь каждый user знает в какой soical он находится 
        //public User()
        //{
        //    wallOffriends = new FriendsWall(this);
        //}


    }
}
