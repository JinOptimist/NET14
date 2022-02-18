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
        }
    }
}
