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
        private static int _saltLengthLimit = 32;
        public List<User> users { get; set; } = new List<User>();
        public  User _currentUser; 

        public User Autorization(string email, string password)
        {
            var user = users.FirstOrDefault(user =>
            user.Email == email
            && user.Password == GetHashOfPassword(password, user.Salt));

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
            var Salt = GetSalt();
            var Password = GetHashOfPassword(password, Salt);
            

            var user = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Age = Age,
                Salt = Salt,
                Password = Password,

            };
            user.wallOffriends.social = this;
            users.Add(user);

            _currentUser = user;
            return user;
        }

        private string GetHashOfPassword(string password, byte[] salt) //This method return hash of password
        {
            var md5 = MD5.Create();
            var hashPassword = md5.ComputeHash(Encoding.UTF8.GetBytes(password).Concat(salt).ToArray()); //Compute password and salt
            return Convert.ToBase64String(hashPassword);
        }

        private byte[] GetSalt() // This method return unique salt (byte[])
        {
            return GetSalt(_saltLengthLimit);
        }
        private byte[] GetSalt(int maximumSaltLength) //This method makes salt
        {
            var salt = new byte[maximumSaltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }

    }
}
