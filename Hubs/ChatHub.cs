using System.Linq;
using System.Threading.Tasks;
using DotnetChatApp.Database;
using Microsoft.AspNetCore.SignalR;

namespace AspNetCoreAngularSignalR.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ModelContext db;

        public ChatHub(ModelContext db)
        {
            this.db = db;
        }
        public async Task SendMessage(string user, string message)
        {
            User u = db.Users.FirstOrDefault(n => n.Username == user);
            if (u == null)
            {
                u = new User
                {
                    Username = user
                };
                db.Users.Add(u);
                db.SaveChanges();
            }

            db.Messages.Add(new Message
            {
                UserID = u.UserID,
                Content = message
            });

            db.SaveChanges();
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
