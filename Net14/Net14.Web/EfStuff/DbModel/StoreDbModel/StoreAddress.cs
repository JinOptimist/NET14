using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.DbModel
{
    public class StoreAddress : BaseModel
    {
        public string Country { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int House { get; set; }
        public int Room { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
