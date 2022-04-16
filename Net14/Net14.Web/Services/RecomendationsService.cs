using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.Services.Enums;
using Net14.Web.Models;
using AutoMapper;

namespace Net14.Web.Services
{
    public class RecomendationsService
    {
        private SocialUserRepository _socialUserRepository;
        private UserService _userService;
        private IMapper _mapper;
        private UserSocial _currentUser;

        public RecomendationsService(SocialUserRepository socialUserRepository,
            IMapper mapper, UserService userService)
        {
            _socialUserRepository = socialUserRepository;
            _mapper = mapper;
            _userService = userService;
            _currentUser = _userService.GetCurrent();
        }

        private List<SocialUserRecomendationViewModel> GetAgeRate(List<SocialUserRecomendationViewModel> users) //Рейтинг по возрасту
        {
            var _currentUser = _userService.GetCurrent();
            const int fiveYearsDifferent = 2;
            const int tenYearsDifferent = 4;
            const int fifteenYearsDifferent = 5;


            foreach (SocialUserRecomendationViewModel user in users)
            {
                user.RecomendationRate = 0;

                var differentInAge = Math.Abs(_currentUser.Age - user.Age);
                if (differentInAge == 0)
                {
                    user.RecomendationRate += (int)UserRecomendationRatesEnum.Age;
                }
                else if (differentInAge <= 5)
                {
                    user.RecomendationRate += (int)UserRecomendationRatesEnum.Age / fiveYearsDifferent;
                }
                else if (differentInAge <= 10 && differentInAge > 5)
                {
                    user.RecomendationRate += (int)UserRecomendationRatesEnum.Age / tenYearsDifferent;
                }
                else if (differentInAge <= 15 && differentInAge > 10)
                {
                    user.RecomendationRate += (int)UserRecomendationRatesEnum.Age / fifteenYearsDifferent;
                }
            }
            return users;
        }

        private List<SocialUserRecomendationViewModel> GetCityRate(List<SocialUserRecomendationViewModel> users)
        {
            var _currentUser = _userService.GetCurrent();


            foreach (SocialUserRecomendationViewModel user in users)
            {
                if (_currentUser.City.ToLower() == user.City.ToLower())
                {
                    user.RecomendationRate += (int)UserRecomendationRatesEnum.City;
                }
            }
            return users;
        }



        private List<SocialUserRecomendationViewModel> GetCountryRate(List<SocialUserRecomendationViewModel> users)
        {
            var _currentUser = _userService.GetCurrent();

            foreach (SocialUserRecomendationViewModel user in users)
            {
                if (_currentUser.Country.ToLower() == user.Country.ToLower()) 
                {
                    user.RecomendationRate += (int)UserRecomendationRatesEnum.Country;
                }
            }
            return users;
        }

        private List<SocialUserRecomendationViewModel> GetSameFriendRate(List<SocialUserRecomendationViewModel> users)
        {
            var _currentUser = _userService.GetCurrent();
            SocialUserRecomendationViewModel model;
            var dbUsers = _socialUserRepository.GetAll();

            foreach (UserSocial user in dbUsers)
            {
                var SameFriends = user.Friends.Intersect(_currentUser.Friends);
                model = users.Single(userViewModel => userViewModel.Id == user.Id);
                model.RecomendationRate += (int)UserRecomendationRatesEnum.SameFriend * SameFriends.Count();
                model.SameFriendsCount = SameFriends.Count();
                model.SameFriends = _mapper.Map<List<SocialUserRecomendationViewModel>>(SameFriends);
            }

            return users;
        }

        private List<SocialUserRecomendationViewModel> GetGroupsRate(List<SocialUserRecomendationViewModel> users)
        {
            int sameGroupTagsCount;
            SocialUserRecomendationViewModel model;
            var currentUser = _userService.GetCurrent();
            var currentUserGroupTags = currentUser.Groups
                .Select(group => group.Tags
                        .Select(tag => tag.Tag))
                .SelectMany(group => group)
                .Distinct()
                .ToList();
            var dbUsers = _socialUserRepository.GetAll();

            List<string> dbUserGroupTags;
            foreach (UserSocial user in dbUsers) 
            {
                dbUserGroupTags = user
                    .Groups
                    .Select(group => group.Tags
                            .Select(tag => tag.Tag))
                    .SelectMany(group => group)
                    .Distinct()
                    .ToList();
                sameGroupTagsCount = dbUserGroupTags.Intersect(currentUserGroupTags).Count();
                model = users.Single(userView => userView.Id == user.Id);
                model.RecomendationRate += (int)UserRecomendationRatesEnum.SameGroupTag * sameGroupTagsCount;
            }

            return users;
        }


        public List<SocialUserRecomendationViewModel> GetUserRecomendation() 
        {
            var dbUsers = _socialUserRepository.GetAll();
            var viewModelUsers = _mapper.Map<List<SocialUserRecomendationViewModel>>(dbUsers);

            GetAgeRate(viewModelUsers);
            GetCityRate(viewModelUsers);
            GetCountryRate(viewModelUsers);
            GetSameFriendRate(viewModelUsers);
            GetGroupsRate(viewModelUsers);

            var result = viewModelUsers
                .OrderByDescending(user => user.RecomendationRate)
                .Where(user => user.Id != _currentUser.Id)
                .ToList();

            return result;
        }


    }
}
