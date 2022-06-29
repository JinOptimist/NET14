using Microsoft.EntityFrameworkCore;
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
        public List<WordDbModel> GetAll()
        {
            return _webContext.Words.ToList();
        }
        public WordDbModel Get(int id)
        {
            return _webContext
                .Words
                .FirstOrDefault(x => x.Id == id);
        }
        public void Remove(WordDbModel dbModel)
        {
            _webContext.Words.Remove(dbModel);
            _webContext.SaveChanges();
        }
        public void Save(WordDbModel dbModel)
        {
            _webContext.Words.Add(dbModel);
            _webContext.SaveChanges();
        }
        

    }
}
