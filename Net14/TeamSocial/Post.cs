using System;
using System.Collections.Generic;
using System.Text;

namespace TeamSocial
{
    public class Post
    {
        public string NameOfUserWhoPosted { get; set; }
        public string Image { get; set; } = "Image";
        public string AdditionalInformation { get; set; }
        public int Likes { get; set; }
        public DateTime DateOfPosting { get; set; } = DateTime.Now.ToLocalTime();



    }
}
