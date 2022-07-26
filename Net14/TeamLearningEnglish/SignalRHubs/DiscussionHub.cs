using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using TeamLearningEnglish.EfStuff.Repository;
using TeamLearningEnglish.Models;
using TeamLearningEnglish.Services;

namespace TeamLearningEnglish.SignalRHubs
{
    public class DiscussionHub : Hub
    {
        private UserService _userService;
        private MessageDiscussionRepository _messageDiscussionRepository;
        private DiscussionRepository _discussionRepository;
        public DiscussionHub(
            UserService userService,
            MessageDiscussionRepository messageDiscussionRepository, 
            DiscussionRepository discussionRepository)
        {
            _userService = userService;
            _messageDiscussionRepository = messageDiscussionRepository;
            _discussionRepository = discussionRepository;
        }

        public void ClickMessage()
        {
            Clients.All.SendAsync("ClickMessage");
        }
        public void AddMessage(string message)
        {
            var name = _userService.GetCurrent()?.FirstName ?? "no name";
            Clients.All.SendAsync("AddMessage", message, name);
        }
    }
}
