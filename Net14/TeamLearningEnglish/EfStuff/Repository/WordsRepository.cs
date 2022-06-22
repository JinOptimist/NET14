using System.Collections.Generic;
using System.Linq;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff.Repository
{
    public class WordsRepository
    {
        private WebDbContext _webContext;

        public WordsRepository(WebDbContext webContext)
        {
            _webContext = webContext;
        }
        public List<WordsDbModel> GetAll()
        {
            return _webContext.Words.ToList();
        }
        public WordsDbModel Get(int id)
        {
            return _webContext.Words.FirstOrDefault(x => x.Id == id);
        }
        public List<WordCommentDbModel> GetComments(int id)
        {
            return _webContext.WordComment.Where(x => x.Word.Id == id).ToList();
        }
        public void Remove(WordsDbModel dbModel)
        {
            _webContext.Words.Remove(dbModel);
            _webContext.SaveChanges();
        }
        public void SaveWord(WordsDbModel dbModel)
        {
            _webContext.Words.Add(dbModel);
            _webContext.SaveChanges();
        }
        public void SaveComment(WordCommentDbModel dbModel)
        {
            _webContext.WordComment.Add(dbModel);
            _webContext.SaveChanges();
        }

    }
}
