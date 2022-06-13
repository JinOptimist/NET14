using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.DbModel
{
    public class Basket : BaseModel
    {
        
        public virtual List<Product> Products { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual UserSocial User { get; set; }
    }
}
