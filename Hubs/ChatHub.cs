using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetChatApp.Database;
using Microsoft.AspNetCore.SignalR;

namespace AspNetCoreAngularSignalR.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ModelContext db;
        private HashSet<string> connections;

        public ChatHub(ModelContext db)
        {
            this.db = db;
            connections = new HashSet<string>();
        }

        public override Task OnConnectedAsync()
        {
            connections.Append(Context.ConnectionId);
            
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task JoinRoom(string nick)
        {
            bool connected = await OnUserJoined(nick);
            if(connected){
                await Clients.All.SendAsync("JoinedRoom", nick);
            } else {
                await Clients.Caller.SendAsync("ShowError", "Nick have already been taken!");
            }
            
        }
        


        private async Task<bool> OnUserJoined(string nick)
        {
            // IsConnected will be controlled by the client who wants to get the same nick

            if (db.Users.Any(n => n.Username == nick && n.IsConnected == true))
                return false;

            return await AddUser(nick);
        }

        private async Task<bool> AddUser(string nick){
            User u = new User();
            u.Username = nick;
            u.CurrentClientID = Context.ConnectionId;
            u.IsConnected = true;
            db.Users.Add(u);

            // send all other clients to userAdded(nick)
            return (0 < await db.SaveChangesAsync());
        }

        private async Task<bool> RemoveUser(string nick){
            db.Users.Remove(db.Users.FirstOrDefault(n => n.Username == nick));

            // send all other clients to userRemoved(nick)
            return (0 < await db.SaveChangesAsync());
        }




    }
}
