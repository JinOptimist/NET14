using Net14.Web.EfStuff.EnumStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.DbModel
{
    public class Product : BaseModel
    {

        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public CoolCategories CoolCategories { get; set; }
        public CoolColors CoolColors{ get; set; }
        public BrandСategories BrandCategories { get; set; }
        public Gender Gender { get; set; }
        public CoolMaterial CoolMaterial { get; set; }
        public virtual List<Size> Sizes { get; set; }
        public virtual List<Basket> Baskets { get; set; }
        public virtual List<StoreImage> StoreImages { get; set; }

        
    }
}
