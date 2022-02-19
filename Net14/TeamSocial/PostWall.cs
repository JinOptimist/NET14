using System;
using System.Collections.Generic;
using System.Text;

namespace TeamSocial
{
    public class PostWall
    {
        public void CreatePostWall()
        {
            List<Post> wall = new List<Post>();
            Post post = new Post();

            for (int i = 0; i < wall.Count; i++)
            {
                string ImageUrl = post.ImageUrl;
                int Likes = post.Likes;
                post.Comments = "Very Good News!";
                post.TypePost = "News";
                DateTime DateOfPosting = post.DateOfPosting;
                Console.WriteLine(ImageUrl + " " + post.TypePost + " " + post.Comments + " " + post.Likes);
                wall.Add(post);

            }
        }
        
        public void 
    }   
  
}
