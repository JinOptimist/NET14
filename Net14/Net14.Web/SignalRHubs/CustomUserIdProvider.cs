using Microsoft.AspNetCore.SignalR;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Net14.Web.SignalRHubs
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Claims.FirstOrDefault(x => x.Type.Equals("Id", StringComparison.OrdinalIgnoreCase))?.Value;
        }
    }
}
