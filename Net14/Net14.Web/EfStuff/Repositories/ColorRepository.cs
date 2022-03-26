using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.Repositories
{
    public class ColorRepository : BaseRepository<Color>
    {
        public ColorRepository(WebContext context):base(context)
        {
        }
    }
}
