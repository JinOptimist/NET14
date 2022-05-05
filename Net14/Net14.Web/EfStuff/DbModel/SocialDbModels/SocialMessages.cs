using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSocial;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class SocialMessages : BaseModel
    {
        public virtual UserSocial Sender { get; set; }
        public virtual UserSocial Reciever { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

    }
}