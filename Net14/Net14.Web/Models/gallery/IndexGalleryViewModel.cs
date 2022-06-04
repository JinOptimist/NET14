using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.gallery
{
    public class IndexGalleryViewModel
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int TotalCount { get; set; }

        public int PageCount =>
            TotalCount % PerPage == 0
                ? TotalCount / PerPage
                : TotalCount / PerPage + 1;

        public List<ImageViewModel> Images { get; set; }
    }
}
