using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;

namespace Net14.Web.Models
{
    public class FilesWithLastViewModel
    {
        public List<FilesViewModel> Files { get; set; }
        public List<FilesViewModel> LastFiles { get; set; }

    }
}