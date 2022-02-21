using System;
using System.Collections.Generic;
using System.Text;
using SocialWeb;

namespace TeamSocial
{
    class SocialDrawer
    {
        
        public void DrawAllUsers(Social social)
        {
            foreach (var allUsers in social.users)
                Console.WriteLine("\t" + allUsers.FirstName + " " + allUsers.LastName);
                
            
        }

    }
}
