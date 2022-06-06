using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.store
{
    public class CatalogPageViewModel
    {
        public int Page { get; set; }
        public List<ProductViewModel> Products { get; set; }
      
    }
}
