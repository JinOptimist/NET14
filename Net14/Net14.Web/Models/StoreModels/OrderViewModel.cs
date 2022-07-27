using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.EnumStore;

namespace Net14.Web.Models.store
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int Sum { get; set; }
        public string Comment { get; set; }
        public DateTime OrderDate { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public DeliveryOrPickup DeliveryOrPickup { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public DeliveryAddressViewModel DeliveryAddress { get; set; }
        public StoreAddressViewModel StoreAddress { get; set; }

    }
}
