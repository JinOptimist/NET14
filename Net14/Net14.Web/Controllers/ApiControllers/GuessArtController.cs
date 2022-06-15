using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.GuessAppDbModels;
using Net14.Web.EfStuff.Repositories.GuessArtRepositories;
using Microsoft.AspNetCore.Authorization;
using Net14.Web.Models.GuessArtModels;
using AutoMapper;
using Net14.Web.EfStuff.DbModel.GuessAppDbModels.Enums;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Services;

namespace Net14.Web.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GuessArtController : ControllerBase
    {
        RoomRepository _roomRepository;
        IMapper _mapper;
        UserService _userService;
        public GuessArtController(RoomRepository roomRepository,
            IMapper mapper,
            UserService userService) 
        {
            _userService = userService;
            _mapper = mapper;
            _roomRepository = roomRepository;
        }
        [HttpGet]
        public List<RoomViewModel> GetRooms() 
        {
            var rooms = _mapper.Map<List<RoomViewModel>>(_roomRepository.GetAll());
            return rooms;
        }

        [HttpGet]
        public RoomViewModel GetSingleRoom(int id) 
        {
            var roomDb = _roomRepository.Get(id);
            var currentUser = _userService.GetCurrent();
            _roomRepository.JoinRoom(currentUser, roomDb);
            var roomViewModel = _mapper.Map<RoomViewModel>(roomDb);

            return roomViewModel;
        }

        [HttpGet]
        public bool JoinRoom(int roomId) 
        {
            var currentUser = _userService.GetCurrent();
            var room = _roomRepository.Get(roomId);

            if (_roomRepository.JoinRoom(currentUser, room)) 
            {
                return true;
            }

            return false;
        }

        [HttpGet]
        public bool LeaveRoom(int roomId)
        {
            var currentUser = _userService.GetCurrent();
            var room = _roomRepository.Get(roomId);

            if (_roomRepository.LeaveGroup(currentUser, room)) 
            {
                return true;
            }

            return false;
        }







    }
}
