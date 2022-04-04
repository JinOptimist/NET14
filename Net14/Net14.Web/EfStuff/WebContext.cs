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

        public DbSet<ImageComment> ImageComments { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Product> Products { get; set; }

        

        public DbSet<Size> Sizes { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        public DbSet<StoreImage> StoreImages { get; set; }

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


            modelBuilder.Entity<Basket>()
               .HasMany(basket => basket.Products)
               .WithMany(product => product.Baskets);

            modelBuilder.Entity<Product>()
               .HasMany(Product =>Product.StoreImages)
               .WithOne(StoreImage => StoreImage.Product);


            base.OnModelCreating(modelBuilder);
        }
    }
}
