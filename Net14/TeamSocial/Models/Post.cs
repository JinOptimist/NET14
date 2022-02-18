using System;
using System.Collections.Generic;
using System.Text;

namespace TeamSocial
{
    public class Post
    {
        public string NameOfUserWhoPosted { get; set; }
        public string ImageUrl { get; set; } = "ImageUrl";
        public string AdditionalInformation { get; set; }
        public int Likes { get; set; } = 0;
        public DateTime DateOfPosting { get; set; } = DateTime.Now.ToLocalTime();



    }
}
