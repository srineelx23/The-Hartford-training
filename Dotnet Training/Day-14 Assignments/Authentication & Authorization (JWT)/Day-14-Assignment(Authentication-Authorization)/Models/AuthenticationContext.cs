using Microsoft.EntityFrameworkCore;

namespace Day_14_Assignment_Authentication_Authorization_.Models
{
    public class AuthenticationContext:DbContext
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
