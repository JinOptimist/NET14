using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.DbModel
{
    public class SubСategories : BaseModel
    {
        public string Name { get; set; }

        public virtual Сategories Catigories { get; set; }

    }
}
