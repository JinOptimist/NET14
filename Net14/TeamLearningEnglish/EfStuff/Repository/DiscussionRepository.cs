                       using System.Collections.Generic;
using System.Linq;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff.Repository
{
    public class DiscussionRepository : BaseRepository<DiscussionDbModel>
    {
        public DiscussionRepository(WebDbContext webContext):base(webContext)
        {
        }
        
    }
}
