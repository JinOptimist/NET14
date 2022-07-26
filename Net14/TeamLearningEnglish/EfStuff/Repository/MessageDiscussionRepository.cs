                       using System.Collections.Generic;
using System.Linq;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff.Repository
{
    public class MessageDiscussionRepository : BaseRepository<MessageDiscussionDbModel>
    {
        public MessageDiscussionRepository(WebDbContext webContext):base(webContext)
        {
        }
        
    }
}
