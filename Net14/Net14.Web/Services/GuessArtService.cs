using Microsoft.AspNetCore.Http;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.Models.SocialModels;
using Net14.Web.Models;
using AutoMapper;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Net14.Web.EfStuff.DbModel;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Net14.Web.EfStuff.Repositories.GuessArtRepositories;

namespace Net14.Web.Services
{
    public class GuessArtService
    {
        private SocialUserRepository _socialUserRepository;
        private RoomRepository _roomRepository;
        private IMapper _mapper;

        [AutoRegister]
        public GuessArtService(
            SocialUserRepository socialUserRepository,
            IMapper mapper,
            RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
            _socialUserRepository = socialUserRepository;
            _mapper = mapper;
        }

        public bool UserDisconnect(int userId, int roomId) 
        {
            var room = _roomRepository.Get(roomId);
            var user = _socialUserRepository.Get(userId);

            if (_roomRepository.LeaveGroup(user, room)) 
            {
                return true;
            }

            return false;
        }
    }
}
