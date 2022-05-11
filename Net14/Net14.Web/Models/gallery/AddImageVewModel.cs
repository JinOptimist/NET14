using Microsoft.AspNetCore.Http;
using Net14.Web.Models.CustomValidationAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.gallery
{
    public class AddImageVewModel
    {
        [Required]
        public string Name { get; set; }

        [MyRange(0 , 100)]
        public int Rate { get; set; }

        //[Required]
        //public string Url { get; set; }

        public IFormFile GirlImage { get; set; }
    }
}
