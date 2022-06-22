using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class SocialProfileViewModel
    {
        public int Id { get; set; }
        public bool IsFriend { get; set; }
        public bool IsRequested { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserPhoto { get; set; }
        public string Email { get; set; }
        public int UserGroupsCount { get; set; }
        public int UserFriendsCount { get; set; }
        public List<SocialPhotoViewModel> UserPhotos { get; set; } = new List<SocialPhotoViewModel>();
        public List<SocialPostViewModel> UserPost { get; set; } = new List<SocialPostViewModel>();
    }
}

