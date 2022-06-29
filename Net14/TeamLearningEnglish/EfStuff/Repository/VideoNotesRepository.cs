using System.Collections.Generic;
using System.Linq;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff.Repository
{
    public class VideoNotesRepository : BaseRepository<VideoNotesDbModel>
    {
        public VideoNotesRepository(WebDbContext webContext) : base(webContext)
        {
        }
    }
}
