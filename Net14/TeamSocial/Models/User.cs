using System;
using System.Collections.Generic;
using TeamSocial;

namespace SocialWeb
{
    public class User
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public DateTime DateOfRegistration { get; } = DateTime.Now.ToLocalTime();

        public Wall wallOfUser = new Wall();
        public List<User> friends { get; set; } = new List<User>();


    }


}