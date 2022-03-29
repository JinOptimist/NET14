using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.Repositories
{
    public class SizeRepository : BaseRepository<Color>
    {
        public SizeRepository(WebContext context):base(context)
        {
        }
    }
}
