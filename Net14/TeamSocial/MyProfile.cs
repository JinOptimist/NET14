using SocialWeb;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeamSocial
{
    class MyProfile
    {


        public void ShowProfile(User user)
        {
            Console.Clear();
            Console.WriteLine("\t\t== My Profile ==");
            Console.WriteLine("\t\t\t\t\t\t" + DateTime.Now);
            Console.WriteLine($"\tFirst name: {user.FirstName} \n\tLast name: {user.LastName} ");
            Console.WriteLine($"\tEmail: {user.Email}");
            Console.WriteLine($"\tAge: {user.Age}");
            Console.WriteLine($"\tDate of registration: {user.DateOfRegistration}");
            Console.WriteLine();

        }
    }
}
