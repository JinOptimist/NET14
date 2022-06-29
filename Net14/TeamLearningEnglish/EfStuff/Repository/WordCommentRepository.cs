using System.Collections.Generic;
using System.Linq;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff.Repository
{
    public class WordCommentRepository
    {
        private WebDbContext _webContext;

        public WordCommentRepository(WebDbContext webContext)
        {
            _webContext = webContext;
        }
        
        public List<WordCommentDbModel> Get(int wordId)
        {
            return _webContext.WordComment.Where(x => x.Word.Id == wordId).ToList();
        }
        public void Remove(WordCommentDbModel dbModel)
        {
            _webContext.WordComment.Remove(dbModel);
            _webContext.SaveChanges();
        }
        public void Save(WordCommentDbModel dbModel)
        {
            _webContext.WordComment.Add(dbModel);
            _webContext.SaveChanges();
        }

    }
}
