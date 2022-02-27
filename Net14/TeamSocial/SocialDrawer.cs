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
            Console.WriteLine($"\tCountry: {user.Country}");
            Console.WriteLine($"\tCity: {user.City}");
            Console.WriteLine($"\tDate of registration: {user.DateOfRegistration}");
            Console.WriteLine();

        }

        public void DrawAllUsers(Social social)
        {
            foreach (var allUsers in social.users)
                Console.WriteLine("\t" + allUsers.FirstName + " " + allUsers.LastName);
                
            
        }

        public string ShowSettingsOfUser(User user)
        {
            string[] operations = { "name", "place", "age", "x"};
            while (true)
            {

                DrawAProfile(user);
                Console.WriteLine("To open user's settings enter 's' of 'x' to exit");
                var option = Console.ReadKey(true);
                if (option.KeyChar == 's')
                {
                    Console.WriteLine("Select parameter to change:");
                    Console.WriteLine("\t\tEnter 'name' to change the firstname or lastname");
                    Console.WriteLine("\t\tEnter 'place' to chage the country or city");
                    Console.WriteLine("\t\tEnter 'age' to change the age of user");
                    while (true) 
                    {
                        var operation = Console.ReadLine();
                        if (Array.Exists(operations, element => element == operation))
                        {
                            Changeinformation(operation, user);
                            break;

                        }
                        Console.WriteLine("There's no such commmand");
                        continue;
                    }
                }
                else if (option.KeyChar == 'x')
                {
                    SocialMenu.Start();
                }
                else
                {
                    Console.WriteLine("There's no such command");
                    continue;

                }
            }
        }
        public static void Changeinformation(string option, User user)
        {
            if (option == "name")
            {
                Console.WriteLine("Enter new data or do not enter anything, so as not to change the current: ");
                Console.Write("Enter new FirstName: ");
                var name = Console.ReadLine();
                Console.Write("Enter new LastName: ");
                var lastname = Console.ReadLine();
                user.settings.ChangeName(name, lastname);
            }
            else if (option == "place")
            {
                Console.WriteLine("Enter new place: ");
                Console.Write("Enter country: ");
                var country = Console.ReadLine();
                Console.Write("Enter city: ");
                var city = Console.ReadLine();
                user.settings.ChangeCountryAndOrCity(country, city);
            }
            else if (option == "age")
            {
                Console.WriteLine("Enter new age: (ex: 20)");
                var age = Int32.Parse(Console.ReadLine());
                user.settings.ChangeAge(age);
            }
        }

        public void DrawPostRegistration(User user, Post post)
        {
        //    string enumpost = Post.TypePost.Registartion.ToString();

            Console.WriteLine($"#######################################################################");
            Console.WriteLine($"Type POST: {post.TypePost}      Date of registration: {user.DateOfRegistration}\n");
            Console.WriteLine($"{user.FirstName} {user.LastName} has joined the social network!\n\n");        
            Console.WriteLine($"Here is the comment he made: \n\"{post.Comments}\"");
        }

        public void DrawPostAddFriends(User user, Post post)
        {
        //    string enumpost = Post.TypePost.AddFriend.ToString();

            Console.WriteLine($"#######################################################################");
            Console.WriteLine($"Type POST: {post.TypePost}       Friend request from: {post.DateOfPosting}\n");
            Console.WriteLine($"{user.FirstName} {user.LastName} wants to add you as a friend!\n\n");
            Console.WriteLine($"Сomments: \n\"{post.Comments}\"");
        }

    }
}
