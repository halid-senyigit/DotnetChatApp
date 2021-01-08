using Microsoft.EntityFrameworkCore;

namespace DotnetChatApp.Database 
{
    public class ModelContext : DbContext 
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base (options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
