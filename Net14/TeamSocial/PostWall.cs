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
                post.Comments = "Hello everyone, I am very glad to be with YOU!";                
                DateTime DateOfPosting = post.DateOfPosting;
                wall.Add(post);
                var drawer = new SocialDrawer();
                drawer.DrawPostRegistration(user1, post);
            

        }        
     
    }   
  
}
