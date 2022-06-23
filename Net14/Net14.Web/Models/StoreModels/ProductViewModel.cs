using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.store
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Order { get; set; }
        public List<string> Sizes { get; set; }
        public List<string> Images { get; set; }
        public string CoolMaterial  { get; set; }
        public string CoolColors { get; set; }
        public string Gender { get; set; }
        public string BrandCategories { get; set; }
        public string CoolCategories { get; set; }
        public List<RandomImagesViewModel> RandomImages { get; set; }
        public bool InBasket { get; set; } = false;
    }
}
