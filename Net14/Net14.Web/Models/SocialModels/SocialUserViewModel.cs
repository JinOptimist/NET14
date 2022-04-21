using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class SocialUserViewModel
    {
        public int Id { get; set; }
        public string UserPhoto { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public bool IsFriend { get; set; } = false;
        public bool IsBlocked { get; set; } = false;
    }
}

