using System.Collections.Generic;
using System.Linq;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff.Repository
{
    public class MessageRepository : BaseRepository<MessageDbModel>
    {
        public MessageRepository(WebDbContext webContext) : base(webContext)
        {
        }
        public List<MessageDbModel> GetCurrentMessages (UserDbModel sender, UserDbModel reciever)
        {
            return _webContext.Messages.Where(x => x.Sender.Id == sender.Id || x.Receiver.Id == reciever.Id).ToList();
        }
    }
}
