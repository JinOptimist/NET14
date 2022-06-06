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
        public ProductRepository(WebContext context) : base(context)
        {

        }
        public List<Product> GetCategory(string category)
        {
            switch (category)
            {
                case "Bags":
                    return _dbSet.Where(x =>x.CoolCategories == EnumStore.CoolCategories.Bags).ToList();
                case "Run":
                    return _dbSet.Where(x =>x.CoolCategories == EnumStore.CoolCategories.Run).ToList();
                case "Accessories":
                    return _dbSet.Where(x =>x.CoolCategories == EnumStore.CoolCategories.Accessories).ToList();
                case "Men":
                    return _dbSet.Where(x =>x.Gender == EnumStore.Gender.Men).ToList();
                case "Women":
                    return _dbSet.Where(x =>x.Gender == EnumStore.Gender.Women).ToList();
            }
            return new List<Product>();
        }

    }
}
