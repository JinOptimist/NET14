using System.Collections.Generic;
using System.Linq;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff.Repository
{
    public class MessageRepository
    {
        private WebDbContext _webContext;

        public MessageRepository(WebDbContext webContext)
        {
            _webContext = webContext;
        }
        public UserDbModel Get(int id)
        {
            return _webContext.User.FirstOrDefault(x => x.Id == id);
        }
        public void Save(MessageDbModel dbModel)
        {
            _webContext.Messages.Add(dbModel);
            _webContext.SaveChanges();
        }
        public UserDbModel GetCurrentUser(int id)
        {
            return _webContext.User.FirstOrDefault(x => x.Id == id);
        }
        public IQueryable<MessageDbModel> GetCurrentMessages (UserDbModel sender, UserDbModel reciever)
        {
            return _webContext.Messages.Where(x => x.Sender.Id == sender.Id || x.Receiver.Id == reciever.Id);
        }
    }
}
