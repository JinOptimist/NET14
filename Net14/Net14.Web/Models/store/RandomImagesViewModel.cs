using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.store
{
    public class RandomImagesViewModel
    {
        public string Url { get; set; }
        public int ProductId { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
    }
}
