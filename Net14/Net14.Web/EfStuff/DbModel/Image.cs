using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.DbModel
{
    public class Image : BaseModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int Rate { get; set; }

        public virtual List<ImageComment> Comments { get; set; }
    }
}
