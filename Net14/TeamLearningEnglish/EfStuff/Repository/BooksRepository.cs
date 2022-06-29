using System.Collections.Generic;
using System.Linq;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff.Repository
{
    public class BooksRepository : BaseRepository<BookDbModel>
    {
        public BooksRepository(WebDbContext webContext):base(webContext)
        {
        }
        
    }
}
