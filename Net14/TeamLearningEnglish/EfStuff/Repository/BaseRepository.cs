using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff.Repository
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected WebDbContext _webContext;
        protected DbSet<T> _dbSet;
        public BaseRepository(WebDbContext webContext)
        {
            _webContext = webContext;
            _dbSet = webContext.Set<T>();
        }
        public T Get(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public void Remove(T model)
        {
            _dbSet.Remove(model);
            _webContext.SaveChanges();
        }
        public void Save(T model)
        {
            _dbSet.Add(model);
            _webContext.SaveChanges();
        }
        

    }
}
