using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.Repositories
{
    public class StoreImageRepository : BaseRepository<StoreImage>
    {
        public StoreImageRepository(WebContext context) : base(context)
        {
        }
        public List<string> GetRandom(int id, int order = 1)
        {
            return _dbSet
                .Where(x => x.Odrer == order)
                .Where(x => x.Id != id)
                .OrderBy(x => Guid.NewGuid())
                .Select(x=>x.Name)
                .Take(4)
                .ToList();
        }
    }
}
