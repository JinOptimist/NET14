using System;

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

    }
}