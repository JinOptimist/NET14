using Net14.Web.EfStuff.EnumStore;
using Net14.Web.Models.CustomValidationAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class AddImageProductVewModel
    {
        
        public int Id { get; set; }
        public string BrandCategories { get; set; }
        public string Name { get; set; }
        public string NewImageUrl { get; set; }
        public List<string> Images { get; set; }
        

    }
}
