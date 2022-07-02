using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.Models.SocialModels.Enums;

namespace Net14.Web.Models
{
    public class SocialReportViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string CreatingDate { get; set; }

    }
}