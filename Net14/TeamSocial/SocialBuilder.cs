using RandomNameGeneratorLibrary;
using SocialWeb;
using System;
using System.Collections.Generic;
using System.Text;


namespace TeamSocial
{
    public class SocialBuilder
    {
        public Social BuildSocial() 
        {

            var social = new Social();
            for (int i = 1; i < 4; i++)
            {
                var emptyUser = new User()
                {
                    //    FirstName = "Empty"
                    Email = $"user{i}@mail.ru",
                    Password = "12345678",
                };
                social.users.Add(emptyUser);

            }
            return social;
            /*var social = new Social();
            for (int i = 0; i < 3; i++) 
            {
                var name = RandomName();
                var emptyUser = new User()
                {
                    FirstName = name[0],
                    LastName = name[1]
                };
                social.users.Add(emptyUser);
                
            }
            return social;*/
        }

        /*public string[]  RandomName()
        {
            var name = new string[2];
            var personGenerator = new PersonNameGenerator();

            var FirstName = personGenerator.GenerateRandomFirstName();
            var LastName = personGenerator.GenerateRandomLastName();

            name[0] = FirstName;
            name[1] = LastName;
            return name;
           
        }*/
    }
}
