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
        public string Url { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public string Material { get; set; }
        public int Price { get; set; }
       

    }
}
