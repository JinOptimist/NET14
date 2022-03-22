using SocialWeb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using TeamSocial.Exceptions;
using System.Text.RegularExpressions;

namespace TeamSocial
{
    public class Social
    {
        private static int _saltLengthLimit = 32;
        public List<User> users { get; set; } = new List<User>();
        public  User _currentUser;

        public Social() 
        {

        }

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

        public User Registration(string firstName, string lastName, string email, int age, string password, string city = null, string country = null)
        {
            var FirstName = firstName;
            var LastName = lastName;
            var Email = email;
            if (users.Exists(user => user.Email == Email)) //Если такой Email уже есть
            {
                throw new EmailIsAlreadyExistsException($"Email {Email} is already exists");//То говорим, что EmailIsAlredyExists
            }
            if (!Validate(Email)) //Если такого Email нету, но он введен неправильно, то говорим, что InvalidEmailException
            {
                throw new InvalidEmailException($"Email {Email} is invalid");
            }
            var Age = age;
            var City = city;
            var Country = country;
            var Salt = GetSalt();
            var Password = GetHashOfPassword(password, Salt);


            var user = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Age = Age,
                City = city,
                Country = country,
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

        public bool Validate(string emailAddress) //Этот метод проверяет правильность введенного Email
        {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool isValid = Regex.IsMatch(emailAddress, regex, RegexOptions.IgnoreCase);
            return isValid;
        }

    }
}
