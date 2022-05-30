using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
namespace Net14.Web.EfStuff.Repositories
{
    public class SocialMessagesRepository : BaseRepository<SocialMessages>
    {
        public SocialMessagesRepository(WebContext context) : base(context)
        {
        }

        public List<SocialMessages> GetMessagesOfTwoUsers(int firstUser, int secondUser) 
        {
            return _webContext.SocialMessages.Where(message => message.Sender.Id == firstUser && message.Reciever.Id == secondUser
                        ||
                        message.Reciever.Id == firstUser && message.Sender.Id == secondUser).ToList();
        }

        public SocialMessages GetLastMessage(int firstUser, int secondUser) 
        {
            return _webContext.SocialMessages.Where(message => message.Sender.Id == firstUser && message.Reciever.Id == secondUser
                    || message.Reciever.Id == firstUser && message.Sender.Id == secondUser).OrderByDescending(message => message.Date).First();
        }
    }
}
