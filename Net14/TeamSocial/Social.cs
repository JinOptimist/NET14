using SocialWeb;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeamSocial
{
    public class Social
    {
        new public List<User> users { get; set; }
        public void Autorization()
        {

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
        }

        public void DataOutput()
        {
            var FirstName = Console.ReadLine();
            var LastName = Console.ReadLine();
            var Email = Console.ReadLine();
            var Age = Int32.Parse(Console.ReadLine());
            var Password = Console.ReadLine();
            Registration(FirstName, LastName, Email, Age, Password);

        }



    }


}
