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
        public List<BookDbModel> GetAll()
        {
            return _webContext.Books.ToList();
        }
        public BookDbModel Get(int id)
        {
            return _webContext.Books.FirstOrDefault(x => x.Id == id);
        }
        public void Remove (BookDbModel dbModel)
        {
            _webContext.Books.Remove(dbModel);
            _webContext.SaveChanges();
        }
        public void Save(BookDbModel dbModel)
        {
            _webContext.Books.Add(dbModel);
            _webContext.SaveChanges();
        }
        
    }
}
