using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class SocialMessageViewModel
    {
        public SocialUserViewModel Sender { get; set; }
        public SocialUserViewModel Reciever { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}