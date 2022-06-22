using System.Collections.Generic;
using System.Linq;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff.Repository
{
    public class VideoNotesRepository
    {
        private WebDbContext _webContext;

        public VideoNotesRepository(WebDbContext webContext)
        {
            _webContext = webContext;
        }
        public List<VideoNotesDbModel> GetAll()
        {
            return _webContext.VideoNotes.ToList();
        }
        public VideoNotesDbModel Get(int id)
        {
            return _webContext.VideoNotes.FirstOrDefault(x => x.Id == id);
        }
        public void Remove(VideoNotesDbModel dbModel)
        {
            _webContext.VideoNotes.Remove(dbModel);
            _webContext.SaveChanges();
        }
        public void Save(VideoNotesDbModel dbModel)
        {
            _webContext.VideoNotes.Add(dbModel);
            _webContext.SaveChanges();
        }
    }
}
