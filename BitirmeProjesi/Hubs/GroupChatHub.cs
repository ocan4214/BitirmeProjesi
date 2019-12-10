using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BitirmeProjesi.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace BitirmeProjesi.Hubs
{
    public class GroupChatHub : Hub
    {
        public void HelloFRR()
        {
            Clients.All.hello();
        }

        public void Henlo()
        {

            Clients.All.HenloFr();
            
        }

        [Authorize]
        public void JoinGroupChat(string groupChatName, int groupid)
        {
            int uid = Convert.ToInt32(Context.User.Identity.Name);

            using (LogRegDBEntities1 db = new LogRegDBEntities1())
            {
                var user = db.Users.Find(uid);
                var room = db.GroupChats.Where(a => a.GroupChatName == groupChatName && a.GroupId == groupid).First();
                //Katılma butonunu viewde yetkiye göre kullanıcıya gösterilecek.
                if (room != null && !user.Connections.Any(a => a.GroupChatId == room.GroupChatId))
                {
                    var ncon = new Connection() { ConnectionId = Context.ConnectionId, GroupChat = room, isConnected = true, User = user };
                    room.Connections.Add(ncon);
                    user.Connections.Add(ncon);
                    db.SaveChanges();
                    Groups.Add(Context.ConnectionId, groupChatName);
                    Clients.Group(groupChatName).ServerNotification("User " + user.UserName + " has joined the  " + groupChatName + "Chat Room");

                }
                else
                {
                    Clients.Caller.ServerNotification("You are already in the " + groupChatName + " chat room");
                }
            }

        }


        public override Task OnConnected()
        {








            return base.OnConnected();
        }


        public override Task OnDisconnected(bool stopCalled)
        {

            using (LogRegDBEntities1 db = new LogRegDBEntities1())
            {
                


            }


                return base.OnDisconnected(stopCalled);
        }





    }




}