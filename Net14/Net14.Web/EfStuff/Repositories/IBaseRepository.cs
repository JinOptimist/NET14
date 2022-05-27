using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel;

namespace Net14.Web.EfStuff.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        public T Get(int id);
        public List<T> GetAll();
        public void Save(T model);
        public void Remove(T model);
        public bool Any();
        public void SaveList(List<T> models);

    }
}
