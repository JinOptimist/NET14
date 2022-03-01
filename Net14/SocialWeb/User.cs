using System;

namespace SocialWeb
{
    public class User
    {
        public User(string firstName, string lastName, string email, int age, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
            Password = password;

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }

    }
}