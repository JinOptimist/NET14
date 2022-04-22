using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class SocialUserRecomendationUrlViewModel
    {
        public List<SocialUserRecomendationViewModel> Recomendations;
        public string Url { get; set; }

    }
}

