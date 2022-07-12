using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using TeamLearningEnglish.Services;

namespace TeamLearningEnglish.SignalRHubs
{
    public class DiscussionHub : Hub
    {
        private UserService _userService;
        public DiscussionHub(UserService userService)
        {
            _userService = userService;
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
