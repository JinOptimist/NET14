using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class SocialAPIViewModel
    {
        public string Name { get; set; }
        public IEnumerable<SocialAPIMethodViewModel> Methods { get; set; }

    }
}