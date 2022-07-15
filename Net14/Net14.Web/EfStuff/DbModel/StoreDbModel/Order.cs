using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.EnumStore;

namespace Net14.Web.EfStuff.DbModel
{
    public class Order : BaseModel
    {
        public int Sum { get; set; }
        public string Comment { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderDateSend { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public DeliveryOrPickup DeliveryOrPickup { get; set; }
        public virtual List<Product>Products { get; set; }
        public virtual UserSocial UserSocial { get; set; }
        public virtual DeliveryAddress DeliveryAddress { get; set; }
        public virtual StoreAddress StoreAddress { get; set; }

    }
}
