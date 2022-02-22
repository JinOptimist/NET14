using SocialWeb;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeamSocial
{
    public class PostWall
    {

        public List<Post> CreatePost()
        {
            List<Post> wall = new List<Post>();
            Social social = new Social();
            Post onepost = new Post();

            string userone = "WallEmpty";//social._currentUser.FirstName;
            onepost.NameOfUserWhoPosted = userone;
            onepost.Comments = "Create Userrs";//social._currentUser.Age.ToString();

            string ImageUrl = onepost.ImageUrl;
            int Likes = onepost.Likes;
            onepost.Comments = $"User{userone} create!";
            onepost.TypePost = "Create Users";
            DateTime DateOfPosting = onepost.DateOfPosting;

            return wall;
        }
                
        
        public void CreatePostWall()
        {

            List<Post> wallall = CreatePost();
            Post post = new Post();

            for (int i = 0; i < wallall.Count; i++)
            {
                Console.WriteLine($"################################################");
                string usrpost = post.NameOfUserWhoPosted;
                string ImageUrl = post.ImageUrl;
                int Likes = post.Likes;
                post.Comments = "Very Good News!";
                post.TypePost = "News";
                DateTime DateOfPosting = post.DateOfPosting;
                Console.WriteLine($"{ImageUrl}\n {post.TypePost}\n {post.Comments}\n {post.Likes}\n");

                wallall.Add(post);

            }

            wallall.ForEach(value => Console.WriteLine(value));

        }
        
     //   public void 
    }   
  
}
