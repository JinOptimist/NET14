using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff
{
    public class WebContext : DbContext
    {
        public DbSet<Image> Images { get; set; }

        public DbSet<ArtImage> ArtImages { get; set; }

        public WebContext(DbContextOptions options) : base(options)
        {
        }
    }
}
