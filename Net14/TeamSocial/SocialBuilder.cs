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
            /*            for (int i = 1; i < 4; i++)
                        {
                            var emptyUser = new User()
                            {
                                //    FirstName = "Empty"
                                FirstName = $"Empty{i}",
                                Email = $"user{i}@mail.ru",
                                Password = "12345678",

                            };
                            emptyUser.wallOffriends.social = social;
                            social.users.Add(emptyUser);

                        }*/
            var emptyUser1 = new User()
            {
                FirstName = $"Empty1",
                Email = $"user2@mail.ru",
                Password = "12345678",
                City = "Moscow",
                Country = "Russia",
                Age = 44,
            };
            emptyUser1.wallOffriends.social = social;
            social.users.Add(emptyUser1);

            var emptyUser2 = new User()
            {
                //    FirstName = "Empty"
                FirstName = $"Empty2",
                Email = $"user3@mail.ru",
                Password = "12345678",
                City = "Minsk",
                Country = "Belarus",
                Age = 20,
            };
            emptyUser2.wallOffriends.social = social;
            social.users.Add(emptyUser2);

            var emptyUser3 = new User()
            {
                //    FirstName = "Empty"
                FirstName = $"Empty3",
                Email = $"user4@mail.ru",
                Password = "12345678",
                City = "Moscow",
                Country = "Russia",
                Age = 51,
            };
            emptyUser3.friends.Add(emptyUser1);
            emptyUser3.wallOffriends.social = social;
            social.users.Add(emptyUser3);

            return social;
        }

        public string[]  RandomName()
        {
            var name = new string[2];
            var personGenerator = new PersonNameGenerator();

            var FirstName = personGenerator.GenerateRandomFirstName();
            var LastName = personGenerator.GenerateRandomLastName();

            name[0] = FirstName;
            name[1] = LastName;
            return name;
           
        }
    }
}
