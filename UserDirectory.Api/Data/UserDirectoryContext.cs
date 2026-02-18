using Microsoft.EntityFrameworkCore;
using UserDirectory.Api.Models; // Adjust namespace as needed

namespace UserDirectory.Api.Data
{
    public class UserDirectoryContext : DbContext
    {
        public UserDirectoryContext(DbContextOptions<UserDirectoryContext> options)
            : base(options)
        {
        }

        // Add your DbSets here
        public DbSet<User> Users { get; set; }
        // Add other entity sets as needed
    }
}
