using Microsoft.EntityFrameworkCore;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff
{
    public class WebDbContext : DbContext
    {
        public DbSet<WordDbModel> Words { get; set; } // I've described a new table
        public DbSet<UserDbModel> User { get; set; }
        public DbSet<BookDbModel> Books { get; set; }
        public DbSet<WordCommentDbModel> WordComment { get; set; }
        public DbSet<FolderWordDbModel> FolderWord { get; set; }
        public DbSet<MessageDiscussionDbModel> MessagesDiscussion { get; set; }
        public DbSet<DiscussionDbModel> TopicDiscussions { get; set; }

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

            modelBuilder.Entity<FolderWordDbModel>()
                .HasMany(folder => folder.Words)
                .WithOne(word => word.Folder);

            modelBuilder.Entity<UserDbModel>()
                .HasMany(user => user.WhichUserCreated)
                .WithOne(discussion => discussion.Creator);

            modelBuilder.Entity<UserDbModel>()
                .HasMany(user => user.Disscusions)
                .WithMany(discussion => discussion.Users);

            modelBuilder.Entity<UserDbModel>()
                .HasMany(user => user.Messages)
                .WithOne(message => message.Sender);

            modelBuilder.Entity<DiscussionDbModel>()
                .HasMany(discussion => discussion.Messages)
                .WithOne(message => message.Discussion)
                .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }

    }
}
