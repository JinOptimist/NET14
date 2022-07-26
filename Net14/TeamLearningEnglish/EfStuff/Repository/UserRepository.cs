using System.Collections.Generic;
using System.Linq;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff.Repository
{
    public class UserRepository : BaseRepository<UserDbModel>
    {
        public UserRepository(WebDbContext webContext) : base(webContext)
        {
        }
        public UserDbModel GetByEmailAndPass(string email, string password)
        {
            return _dbSet.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
        public bool GetByEmail(string email)
            => _dbSet.Any(x => x.Email == email);
        public bool GetByPassword(string password)
            => _dbSet.Any(x => x.Password == password);
        public bool IsEmailExist(string email) 
            => _dbSet.Any(x => x.Email == email);

        
    }
}
