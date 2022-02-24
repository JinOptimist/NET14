using SocialWeb;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeamSocial
{
    public class PostWall
    {                       
        
        public void CreatePostWall(User user)
        {
            User user1 = user; 
            
            List<Post> wall = new List<Post>();
            Post post = new Post();

            string userone = user1.FirstName;
            post.NameOfUserWhoPosted = userone;
            post.Comments = $"User{userone} create!";
            post.TypePost = "Create Users";
            DateTime DateOfPosting = post.DateOfPosting;
            wall.Add(post);
            var drawer = new SocialDrawer();
            drawer.DrawPost(user1);


            //for (int i = 0; i < wallall.Count; i++)
            //{
            //    Console.WriteLine($"################################################");
            //    string usrpost = post.NameOfUserWhoPosted;
            //    string ImageUrl = post.ImageUrl;
            //    int Likes = post.Likes;
            //    post.Comments = "Very Good News!";
            //    post.TypePost = "News";
            //    DateTime DateOfPosting = post.DateOfPosting;
            //    Console.WriteLine($"{ImageUrl}\n {post.TypePost}\n {post.Comments}\n {post.Likes}\n");

            //    wallall.Add(post);

            //}        

        }
        
     //   public void 
    }   
  
}
