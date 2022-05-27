using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;

namespace Net14.Web.EfStuff.Repositories
{
    public interface ISocialUserRepository : IBaseRepository<UserSocial>
    {
        public List<UserSocial> GetBy(string FullName = null, int Age = 0, string Country = null,
            string City = null, string FirstName = null, string LastName = null);
        public UserSocial GetByEmAndPass(string email, string pass);
        public bool IsEmailExist(string email);
        public bool Exists(int userId);

    }
}
