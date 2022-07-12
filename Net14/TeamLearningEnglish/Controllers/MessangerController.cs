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
    public class MessangerController : Controller
    {
        private UserService _userService;
        private UserRepository _userRepository;

        public MessangerController(
            UserRepository userRepository,
            UserService userService)
        {
            _userService = userService;
            _userRepository = userRepository;
        }
   
        public IActionResult Discussions()
        {
            var topics = new List<TopicForDiscussionViewModel>()
            {
                new TopicForDiscussionViewModel
                {
                    Id = 1,
                    Name = "About apples",
                    CreatorName = "Boris",
                    Rating = 10
                },
                new TopicForDiscussionViewModel
                {
                    Id = 2, 
                    Name = "Talking about new Iphone",
                    CreatorName = "Kirill",
                    Rating = 100
                }
            };

            return View(topics);
        }
       
        

    }
}
