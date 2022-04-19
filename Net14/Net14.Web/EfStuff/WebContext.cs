using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;

namespace Net14.Web.EfStuff
{
    public class WebContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<PostSocial> Posts { get; set; }
        public DbSet<UserSocial> Users { get; set; }
        public DbSet<FileSocial> fileSocial { get; set; }
        public DbSet<SocialComment> SocialComments { get; set; }
        public DbSet<GroupSocial> GroupSocial { get; set; }

        public DbSet<ImageComment> ImageComments { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserFriendRequest> UserFriendRequests { get; set; }

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

            modelBuilder.Entity<UserSocial>()
                .HasMany(x => x.FriendRequestReceived)
                .WithOne(x => x.Receiver);

            modelBuilder.Entity<UserSocial>()
                .HasMany(x => x.FriendRequestSent)
                .WithOne(x => x.Sender);
            


            modelBuilder.Entity<Image>()
                .HasMany(image => image.Comments)
                .WithOne(comment => comment.Image);


            modelBuilder.Entity<Basket>()
               .HasMany(basket => basket.Products)
               .WithMany(product => product.Baskets);

            modelBuilder.Entity<UserSocial>()
             .HasOne(user => user.Basket)
             .WithOne(basket => basket.User);

            modelBuilder.Entity<Product>()
               .HasMany(Product =>Product.StoreImages)
               .WithOne(StoreImage => StoreImage.Product);

            modelBuilder.Entity<Image>()
              .HasMany(image => image.Comments)
              .WithOne(comment => comment.Image);

            modelBuilder.Entity<UserSocial>()
                .HasMany(user => user.Posts)
                .WithOne(post => post.User);
            modelBuilder.Entity<UserSocial>(x =>
            {
                x.HasMany(u => u.Friends)
                .WithMany(uf => uf.WhoFriends);
            });


            modelBuilder.Entity<PostSocial>()
                .HasMany(post => post.Comments)
                .WithOne(comment => comment.Post);

            modelBuilder.Entity<GroupSocial>()
                .HasMany(group => group.Members)
                .WithMany(user => user.Groups);

            modelBuilder.Entity<UserSocial>().Property(u => u.UserPhoto).HasDefaultValue("/images/Social/User.jpg");

            base.OnModelCreating(modelBuilder);
        }



      

    }
}
