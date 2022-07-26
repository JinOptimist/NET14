using Microsoft.AspNetCore.Mvc;
using TeamLearningEnglish.EfStuff.Repository;
using TeamLearningEnglish.Models;
using TeamLearningEnglish.Services;

namespace TeamLearningEnglish.Controllers.ApiControllers
{
    public class SendMessageController : ControllerBase
    {
        private DiscussionRepository _discussionRepository;
        private MessageDiscussionRepository _messageDiscussionRepository;
        private UserService _userService;

        public SendMessageController(
            DiscussionRepository discussionRepository,
            MessageDiscussionRepository messageDiscussionRepository, 
            UserService userService)
        {
            _discussionRepository = discussionRepository;
            _messageDiscussionRepository = messageDiscussionRepository;
            _userService = userService;
        }

        [HttpPost]
        public bool AddMessageToDiscussion(MessageDiscussionViewModel message)
        {
            var discussionDbModel = _discussionRepository.Get(message.DiscussionId);
            var currentUser = _userService.GetCurrent();

            var messageDbModel = new MessageDiscussionDbModel
            {
                Discussion = discussionDbModel,
                Text = message.Text,
                Sender = currentUser
            };
            _messageDiscussionRepository.Save(messageDbModel);

            return true;
        }
    }
}
