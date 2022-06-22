using System.Collections.Generic;
using System.Linq;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff.Repository
{
    public class BooksRepository
    {
        private WebDbContext _webContext;

        public BooksRepository(WebDbContext webContext)
        {
            _webContext = webContext;
        }
        public List<BooksDbModel> GetAll()
        {
            return _webContext.Books.ToList();
        }
        public BooksDbModel Get(int id)
        {
            return _webContext.Books.FirstOrDefault(x => x.Id == id);
        }
        public void Remove (BooksDbModel dbModel)
        {
            _webContext.Books.Remove(dbModel);
            _webContext.SaveChanges();
        }
        public void Save(BooksDbModel dbModel)
        {
            _webContext.Books.Add(dbModel);
            _webContext.SaveChanges();
        }
        
    }
}
