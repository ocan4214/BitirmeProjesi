using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace BitirmeProjesi.Hubs
{
    public class GroupChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}