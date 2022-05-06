using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;

namespace Net14.Web.Models
{
    public class FilesWithLastViewModel
    {
        internal ClaimsPrincipal infouser;

        public List<FilesViewModel> Files { get; set; }
        public List<FilesViewModel> LastFiles { get; set; }
        public UserSocial User { get; internal set; }
    }
}