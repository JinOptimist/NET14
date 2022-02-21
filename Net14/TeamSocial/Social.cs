using SocialWeb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace TeamSocial
{
    public class Social
    {
        public List<User> users { get; set; } = new List<User>();
        public  User _currentUser; 

        public User Autorization(string email, string password)
        {
            var user = users.FirstOrDefault(user =>
            user.Email == email
            && user.Password == password);

            if (user != null) 
            {
                _currentUser = user;
                return user;
            }

            return null;
        }

        public User Registration(string firstName, string lastName, string email, int age, string password, string city = null, string country = null)
        {
            var FirstName = firstName;
            var LastName = lastName;
            var Email = email;
            var Age = age;
            var City = city;
            var Country = country;
            var Password = password;

            var user = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Age = Age,
                City = city,
                Country = country,
                Password = Password,

            };
            user.wallOffriends.social = this;
            users.Add(user);

            _currentUser = user;
            return user;
        }

    }
}
