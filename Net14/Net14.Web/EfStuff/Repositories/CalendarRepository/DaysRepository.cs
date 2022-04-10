using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Net14.Web.EfStuff.Repositories
{
    public class DaysRepository : BaseRepository<Days>
    {
        public DaysRepository(WebContext context) : base(context)
        {
        }
    }
}
