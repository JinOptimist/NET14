using System;
using System.Collections.Generic;
using TeamSocial;

namespace SocialWeb
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public int RecomendationPercentage { get; set; } 
        public byte[] Salt { get; set; }
        public DateTime DateOfRegistration { get; set; } = DateTime.Now.ToLocalTime();

        public Wall wallOfUser = new Wall();
        public List<User> friends { get; set; } = new List<User>();

        public FriendsWall wallOffriends;
     //   public PostWall wallpost;
        public Social social { get; set; } //Теперь каждый user знает в какой soical он находится 

        public UserSettings settings { get; set; }
        public User() 
        {
            settings = new UserSettings(this);
            wallOffriends = new FriendsWall(this);

        }

        
    }


}