using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.Repositories
{
    public class SizeRepository : BaseRepository<Size>
    {
        public SizeRepository(WebContext context):base(context)
        {

        }
        public Size GetName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Name == name);
        }
    }
}
