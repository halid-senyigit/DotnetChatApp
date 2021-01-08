namespace DotnetChatApp.Database
{

    public class Message
    {
        public int MessageID { get; set; }

        public string Content { get; set; }


        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
    
}