using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(WebContext context):base(context)
        {

        }
        public List<Product> GetBags()
        {
            return _dbSet.Where(x => x.CoolCategories == EnumStore.CoolCategories.Bags).ToList();

        }
        public List<Product> GetRun()
        {
            return _dbSet.Where(x => x.CoolCategories == EnumStore.CoolCategories.Run).ToList();
                
        }
        public List<Product> GetAccessories()
        {
            return _dbSet.Where(x => x.CoolCategories == EnumStore.CoolCategories.Accessories).ToList();

        }
        public List<Product> GetMen()
        {
            return _dbSet.Where(x => x.Gender == EnumStore.Gender.Men).ToList();

        }
        public List<Product> GetWomen()
        {
            return _dbSet.Where(x => x.Gender == EnumStore.Gender.Women).ToList();

        }

        internal object Accessories()
        {
            throw new NotImplementedException();
        }
    }
}
