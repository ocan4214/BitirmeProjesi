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
    public class JSChatMessage
    {
        public string ChatMessage { get; set; }
        public string Username { get; set; }
        public DateTime PostDate { get; set; }
    }

    public class GroupChatHub : Hub
    {
        [Authorize]
        public void JoinGroupChat(string groupChatName, int groupId)
        {
            int uid = Convert.ToInt32(Context.User.Identity.Name);
            using (LogRegDBEntities1 db = new LogRegDBEntities1())
            {
                var user = db.Users.Find(uid);
                var room = db.GroupChats.Where(a => a.GroupChatName == groupChatName && a.GroupId == groupId).FirstOrDefault();
                //Katılma butonunu viewde yetkiye göre kullanıcıya gösterilecek.
                if (room != null && !user.Connections.Any(a => a.GroupChatId == room.GroupChatId))
                {
                    var ncon = new Connection() { ConnectionId = Context.ConnectionId, GroupChat = room, isConnected = true, User = user };
                    room.Connections.Add(ncon);
                    user.Connections.Add(ncon);
                    db.SaveChanges();
                    Groups.Add(Context.ConnectionId, groupChatName);
                    Clients.Group(groupChatName).ServerNotification("Join Room = User " + user.UserName + " has joined the  " + groupChatName + "Chat Room");
                }
                else
                {
                    Clients.Caller.ServerNotification("Join Room = You are already in the " + groupChatName + " chat room");
                }
            }
        }

        [Authorize]
        public void SendMessage(string groupChatName, int groupId, string message)
        {
            using (LogRegDBEntities1 db = new LogRegDBEntities1())
            {
                int uid = Convert.ToInt32(Context.User.Identity.Name);
                string username = db.Users.Find(uid).UserName;
                var room = db.GroupChats.Where(a => a.GroupChatName == groupChatName && a.GroupId == groupId).FirstOrDefault();
                if (room != null && room.Connections.Where(a => a.UserId == uid).Any())
                {
                    GroupChatMessage chatMessage = new GroupChatMessage() { ChatMessage = message, Username = username, GroupChatId = room.GroupChatId, GroupChat = room, PostDate = System.DateTime.Now };
                    JSChatMessage jSChatMessage = new JSChatMessage() { ChatMessage = message, Username = username, PostDate = System.DateTime.Now };
                    room.GroupChatMessages.Add(chatMessage);
                    db.SaveChanges();
                    Clients.Group(groupChatName,Context.ConnectionId).SendMessageGroupOthers(jSChatMessage);
                    Clients.Caller.SendMessageGroupCaller(jSChatMessage);
                }
                else
                {
                    Clients.Caller.ServerNotification("Send Message = Room does not exist");
                }
            }
        }

        public override Task OnConnected()
        {
            using (var db = new LogRegDBEntities1())
            {
                var user = db.Users.Find(Convert.ToInt32(Context.User.Identity.Name));
                if (user == null)
                {
                    Clients.Caller.ServerNotification("On Connected = User does not exist");
                }
                else
                {
                    string chatName = Context.QueryString["groupChatName"].ToString();
                    var connection = user.Connections.Where(a => a.GroupChat.GroupChatName == chatName).FirstOrDefault();
                    if (connection == null)
                    {
                        Clients.Caller.ServerNotification("On Connected = ChatRoom does not exist");
                    }
                    else
                    {
                        Groups.Add(Context.ConnectionId, connection.GroupChat.GroupChatName);
                        Clients.Caller.ServerNotification("On Connected = Joined to" + connection.GroupChat.GroupChatName);
                    }
                }
            }
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