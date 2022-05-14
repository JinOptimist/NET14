using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.store
{
    public class UserBasketViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
