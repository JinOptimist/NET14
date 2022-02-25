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
