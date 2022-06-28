using Microsoft.AspNetCore.SignalR;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.Repositories.GuessArtRepositories;
namespace Net14.Web.SignalRHubs
{
    public class GuessArtHub : Hub
    {
        private UserService _userService;
        private RoomRepository _roomRepository;

        public GuessArtHub(UserService userService, 
            RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
            _userService = userService;
        }

        public void UserConnect(int roomGroup) 
        {
            var groupName = roomGroup.ToString();
            var currentUser = _userService.GetCurrent();
            if (currentUser == null) 
            {
                Clients.Caller.SendAsync("ConnectionError");
            }
            var currentUserName = $"{currentUser.FirstName} {currentUser.LastName}";

            Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            Clients.Group(groupName).SendAsync("UserJoin", currentUserName, currentUser.Id);
        }

        public void UserLeave(int roomId) 
        {
            var groupName = roomId.ToString();
            var currentUser = _userService.GetCurrent();

            Groups.RemoveFromGroupAsync(currentUser.Id.ToString(), groupName);

            Clients.Groups(groupName).SendAsync("UserLeave", currentUser.Id);
        }
    }
}
