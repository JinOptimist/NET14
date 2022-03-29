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

        public DbSet<ImageComment> ImageComments { get; set; }

     

        public WebContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .HasMany(image => image.Comments)
                .WithOne(comment => comment.Image);

            modelBuilder.Entity<Сategories>()
                .HasMany(cat => cat.SubСategories)
                .WithOne(subCat => subCat.Catigories);


            base.OnModelCreating(modelBuilder);
        }
    }
}
