using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.DbModel
{
    public class ArtRequestImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Style { get; set; }
    }
}
