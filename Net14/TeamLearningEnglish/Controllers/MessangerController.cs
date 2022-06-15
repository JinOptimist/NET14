using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.Controllers
{
    public class MessangerController : Controller
    {
        public IActionResult Messanger()
        {
            var users = new List<UserViewModel>()
            {
               new UserViewModel
               {
                    Id = 1,
                    FirstName = "Ivan",
                    LastName = "Petrov",
                    Age = 19,
                    EnglishLevel = EnglishLevel.Level.Begginer
               },
               new UserViewModel
               {
                   Id = 2,
                   FirstName = "Nasty",
                   LastName = "Kuzmichenok",
                   Age = 20,
                   EnglishLevel = EnglishLevel.Level.Advanced
               },
               new UserViewModel
               {
                   Id = 3,
                   FirstName = "Kirill",
                   LastName = "Perepechin",
                   Age = 21,
                   EnglishLevel = EnglishLevel.Level.PreIntermidiate
               }
            };
            return View(users);
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
