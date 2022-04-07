using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSocial;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class VideoSocial : BaseModel
    {
        public string VideoId { get; set; }
        public string VideoDescription { get; set; }
        public string VideoPreview { get; set; }
        public DateTime TimeOfPosting { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}