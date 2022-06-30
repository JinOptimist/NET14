using System.Collections.Generic;
using System.Linq;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff.Repository
{
    public class WordCommentRepository : BaseRepository<WordDbModel>
    {
        public WordCommentRepository(WebDbContext webContext) : base(webContext)
        {
        }
        
    }
}
