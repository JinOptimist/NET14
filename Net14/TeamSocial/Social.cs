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

        public void Autorization(string email, string password)
        {
            var user = users.FirstOrDefault(user =>
            user.Email == email
            && user.Password == password);

            if (user != null) 
            {
                //Тут запускаем какой-то метод, который покажет нам профиль юзера, которого мы нашли
            }
        }

        public void Registration(string firstName, string lastName, string email, int age, string password)
        {
            var FirstName = firstName;
            var LastName = lastName;
            var Email = email;
            var Age = age;
            var Password = password;

            var user = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Age = Age,
                Password = Password

            };
            Console.WriteLine($"User {firstName} {lastName} was registered");
        }
    }
}
