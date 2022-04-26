using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;

namespace Net14.Web.Models
{
    public class SocialGroupViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public List<SocialPostViewModel> Posts { get; set; }
        public List<SocialUserViewModel> Members { get; set; }
        public int Id { get; set; }
        public bool IsCurUserIsMember { get; set; }
        public List<string> Tags { get; set; } 
    }
}

