using SocialWeb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;

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
            && user.Password == GetHashOfPassword(password));

            if (user != null) 
            {
                _currentUser = user;
                return user;
            }

            return null;
        }

        public User Registration(string firstName, string lastName, string email, int age, string password)
        {
            var FirstName = firstName;
            var LastName = lastName;
            var Email = email;
            var Age = age;
            var Password = GetHashOfPassword(password);

            var user = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Age = Age,
                Password = Password,

            };
            user.wallOffriends.social = this;
            users.Add(user);

            _currentUser = user;
            return user;
        }

        private string GetHashOfPassword(string password) 
        {
            var md5 = MD5.Create();
            var hashPassword = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashPassword);
;        }

    }
}
