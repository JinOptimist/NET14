using Microsoft.AspNetCore.Http;
using Net14.Web.Localize;
using Net14.Web.Models.CustomValidationAttribute;
using System.ComponentModel.DataAnnotations;

namespace Net14.Web.Models.gallery
{
    public class AddImageVewModel
    {
        [Required]
        public string Name { get; set; }

        [MyRange(0, 100,
            ErrorMessageResourceType = typeof(Gallery),
            ErrorMessageResourceName = nameof(Gallery.Gallery_RateError))]
        public int Rate { get; set; }

        //[Required]
        //public string Url { get; set; }

        public IFormFile GirlImage { get; set; }
    }
}
