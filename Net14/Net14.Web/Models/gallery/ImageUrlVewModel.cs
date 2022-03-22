using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.gallery
{
    public class ImageUrlVewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public List<string> Comments { get; set; }
    }
}
