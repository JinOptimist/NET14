using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;

namespace Net14.Web.Models
{
    public class SocialGroupWithHotViewModel
    {
        public SocialGroupViewModel Group { get; set; }
        public List<SocialPostViewModel> HotPosts { get; set; }
    }
}

