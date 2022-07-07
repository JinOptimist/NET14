using Microsoft.EntityFrameworkCore;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff
{
    public class WebDbContext : DbContext
    {
        public DbSet<WordDbModel> Words { get; set; } // I've described a new table
        public DbSet<UserDbModel> User { get; set; }
        public DbSet<TopicForDiscussionDbModel> TopicsForDiscussion { get; set; }
        public DbSet<BookDbModel> Books { get; set; }
        public DbSet<MessageDbModel> Messages { get; set; } 
        public DbSet<WordCommentDbModel> WordComment { get; set; }
        public DbSet<FolderWordDbModel> FolderWord { get; set; }

        public WebDbContext(DbContextOptions options) : base(options)
        {
        }   // the constructor recieves different options, including connectionString

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WordDbModel>()
                .HasMany(word => word.Comments)
                .WithOne(comment => comment.Word)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserDbModel>()
                .HasMany(user => user.SentMessages)
                .WithOne(message => message.Sender);

            modelBuilder.Entity<UserDbModel>()
                .HasMany(user => user.RecievedMessages)
                .WithOne(message => message.Receiver);

            modelBuilder.Entity<FolderWordDbModel>()
                .HasMany(folder => folder.Words)
                .WithOne(word => word.Folder);



            base.OnModelCreating(modelBuilder);
        }

    }
}
