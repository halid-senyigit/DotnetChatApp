using System.Collections.Generic;

namespace DotnetChatApp.Database
{

    public class User
    {
        public int UserID { get; set; }

        public string Username { get; set; }

        public string CurrentClientID { get; set; }

        public bool IsConnected { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
    
}
