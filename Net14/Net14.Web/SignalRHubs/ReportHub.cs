using Microsoft.AspNetCore.SignalR;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.SignalRHubs
{
    public class ReportHub : Hub
    {
        public void SendProgress(string userId, int pageCount, int reportId)
        {
            Clients.User(userId).SendAsync("Progress_Update", pageCount, reportId);
        }
    }
}
