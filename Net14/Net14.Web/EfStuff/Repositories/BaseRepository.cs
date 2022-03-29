﻿using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected WebContext _webContext;
        protected DbSet<T> _dbSet;

        public BaseRepository(WebContext context)
        {
            _webContext = context;
            _dbSet = _webContext.Set<T>();
        }

        public T Get(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public bool Any()
        {
            return _dbSet.Any();
        }

        public void Save(T model)
        {
            _dbSet.Add(model);
            _webContext.SaveChanges();
        }

        public void Remove(T model)
        {
            _dbSet.Remove(model);
            _webContext.SaveChanges();
        }
    }
}
