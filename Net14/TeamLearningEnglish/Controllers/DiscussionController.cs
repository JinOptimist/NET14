using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TeamLearningEnglish.EfStuff;
using TeamLearningEnglish.EfStuff.Repository;
using TeamLearningEnglish.Models;
using TeamLearningEnglish.Services;

namespace TeamLearningEnglish.Controllers
{
    public class DiscussionController : Controller
    {
        private UserService _userService;
        private UserRepository _userRepository;
        private DiscussionRepository _discussionRepository;
        private MessageDiscussionRepository _messageDiscussionRepository;
        private IMapper _mapper;

        public DiscussionController(
            UserRepository userRepository,
            UserService userService, IMapper mapper,
            DiscussionRepository discussionRepository, 
            MessageDiscussionRepository messageDiscussionRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
            _mapper = mapper;
            _discussionRepository = discussionRepository;
            _messageDiscussionRepository = messageDiscussionRepository;
        }

        public IActionResult AllDiscussions()
        {
            var discussionDbModel = _discussionRepository.GetAll();

            var discussionViewModel = _mapper.Map<List<DiscussionViewModel>>(discussionDbModel);

            var indexTopicViewModel = new IndexDiscussionViewModel
            {
                Discussions = discussionViewModel,
            };

            return View(indexTopicViewModel);
        }
        public IActionResult CreateDiscussion(IndexDiscussionViewModel discussionViewModel)
        {
            var dbModel = new DiscussionDbModel()
            {
                Creator = _userService.GetCurrent(),
                Name = discussionViewModel.Name,
            };
            _discussionRepository.Save(dbModel);
            return RedirectToAction("TopicsDiscussions");
        }
        public IActionResult SingleDiscussion(int topicId)
        {
            var topicDbModel = _discussionRepository.Get(topicId);
            var topicViewModel = new DiscussionViewModel
            {
                Id = topicDbModel.Id,
                Name = topicDbModel.Name,
                CreatorName = (topicDbModel.Creator.FirstName + topicDbModel.Creator.LastName).ToString(),
                Messages = topicDbModel.Messages.Select(message => message.Text).ToList(),
            };

            return View(topicViewModel);
        }

    }
}
