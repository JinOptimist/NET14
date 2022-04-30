using Microsoft.AspNetCore.SignalR;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.SignalRHubs
{
    public class NotificationsHub : Hub
    {
        public void SendNotif()  
        {
            Clients.User("1").SendAsync("SendNotif", "new notification motherfucker");
            return;
        }

    }
}
