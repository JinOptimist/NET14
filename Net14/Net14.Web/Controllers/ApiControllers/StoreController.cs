using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private IMapper _mapper;
        private UserService _userService;
        private SocialUserRepository _socialUserRepository;
        private DeliveryAddressRepository _deliveryAddressRepository;
        public StoreController(IMapper mapper, UserService userService, SocialUserRepository socialUserRepository, DeliveryAddressRepository deliveryAddressRepository)
        {
            _mapper = mapper;
            _userService = userService;
            _socialUserRepository = socialUserRepository;
            _deliveryAddressRepository = deliveryAddressRepository;
        }

        public void ChangeMasterData(string firstName, string lastName, string email, string phoneNumber)
        {
            var currentUser = _userService.GetCurrent();
            currentUser.FirstName = firstName;
            currentUser.LastName = lastName;
            currentUser.Email = email;
            currentUser.PhoneNumber = phoneNumber;
            _socialUserRepository.Save(currentUser);
        }
        public void ChangePass(string password)
        {
            var currentUser = _userService.GetCurrent();
            currentUser.Password = password;
            _socialUserRepository.Save(currentUser);
        }
        public void AddDeliveryAdress(string country, int postСode, string city, string street, int house, int room)
        {
            var deliveryAdress = new DeliveryAddress()
            {
                Country = country,
                City = city,
                Street = street,
                House = house,
                PostСode = postСode,
                Room = room
            };
            var currentUser = _userService.GetCurrent();

            currentUser.DeliveryAddress.Add(deliveryAdress);

            _socialUserRepository.Save(currentUser);
        }
        public void ChangeLanguage(Language language)
        {
            var currentUser = _userService.GetCurrent();
            currentUser.Language = language;
            _socialUserRepository.Save(currentUser);
        }


    }
}
