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
            for (int i = 0; i < 3; i++) 
            {
                var emptyUser = new User()
                {
                    FirstName = "Empty"
                };
                social.users.Add(emptyUser);
                
            }
            return social;
        }
    }
}
