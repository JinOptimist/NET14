using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.DbModel
{
    public class Сategories : BaseModel
    {
        public string Name { get; set; }
        public virtual List<SubСategories> SubСategories { get; set; }

    }
}
