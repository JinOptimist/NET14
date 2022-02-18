using System;
using System.Collections.Generic;
using System.Text;
using SocialWeb;

namespace TeamSocial
{
    class SocialDrawer
    {
        public void DrawAProfile(User user) 
        {
            Console.WriteLine($"User {user.FirstName} {user.LastName} profile:\n\n");
            Console.WriteLine($"\tEmail: {user.Email}");
            Console.WriteLine($"\tAge: {user.Age}");
            Console.WriteLine($"\tDate of registration: {user.DateOfRegistration}");
            Console.WriteLine();

        }

        public void DrawAllUsers(Social social)
        {
            foreach (var allUsers in social.users)
                Console.WriteLine("\t" + allUsers.FirstName + " " + allUsers.LastName);
                
            
        }

    }
}
