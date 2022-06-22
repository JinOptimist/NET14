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
        public List<StoreImage> GetRandom(int id, int order = 1)
        {
            return _dbSet
                .Where(x => x.Odrer == order)
                .Where(x => x.Product.Id != id)
                .Where(x=>x.Product.CoolCategories!= EnumStore.CoolCategories.Accessories)
                .Where(x => x.Product.CoolCategories != EnumStore.CoolCategories.Bags)
                .OrderBy(x => Guid.NewGuid())
                .Take(4)
                .ToList();
        }
    }
}
