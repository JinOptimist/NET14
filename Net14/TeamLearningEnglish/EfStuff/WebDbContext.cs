using Microsoft.EntityFrameworkCore;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff
{
    public class WebDbContext : DbContext
    {
        public DbSet<WordsDbModel> Words { get; set; } // I've described a new table
        public DbSet<UserDbModel> User { get; set; }
        public DbSet<TopicForDiscussionDbModel> TopicsForDiscussion { get; set; }
        public DbSet<BooksDbModel> Books { get; set; }
        public WebDbContext(DbContextOptions options) : base(options)
        {
        }   // the constructor recieves different options, including connectionString

    }
}
