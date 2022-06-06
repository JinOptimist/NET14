using Net14.Web.EfStuff.EnumStore;
using Net14.Web.Models.CustomValidationAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class AddProductVewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MyRange(0, 100)]
        public int Quantity { get; set; }

        [Required]
        [MyRange(1, 10000)]
        public int Price { get; set; }
        [Required]
        public List<string> Sizes { get; set; }
        public List<string> CheckedSizes { get; set; }

        public CoolMaterial Material { get; set; }
        public CoolColors Color { get; set; }
        public Gender Gender { get; set; }
        public BrandСategories Brand  { get; set; }
        public CoolCategories Category { get; set; }


    }
}
