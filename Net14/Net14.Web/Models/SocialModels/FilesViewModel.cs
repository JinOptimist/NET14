using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;

namespace Net14.Web.Models
{
    public class FilesViewModel
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        [Required]
        public string Url { get; set; } 
        public SocialUserViewModel Owner { get; set; }
        [Required]
        [StringLength (1000)]
        public string Text { get; set; } 


    }
}