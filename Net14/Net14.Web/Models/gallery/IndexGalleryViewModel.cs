using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.gallery
{
    public class IndexGalleryViewModel
    {
        public int Page { get; set; }
        public List<ImageViewModel> Images { get; set; }
    }
}
