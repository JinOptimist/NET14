using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Net14.Web.EfStuff.EnumStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.store
{
    public class ChecoutViewModel
    {
        public int Sum { get; set; }
        public int Id { get; set; }
        public string Comment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime OrderDate { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public DeliveryOrPickup DeliveryOrPickup { get; set; }
        public List<StoreAddressViewModel> StoreAddress { get; set; }
        public int CheckedStoreAddressId { get; set; }
        public int CheckedDeliveryAddressId { get; set; }
        public List<DeliveryAddressViewModel> DeliveryAddress { get; set; }
        public string PhoneNumber { get; set; }
        public List<ProductViewModel> Products { get; set; }
       
    }
}
