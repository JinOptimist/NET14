using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.DbModel
{
    public class ImageComment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual Image Image { get; set; }
    }
}
