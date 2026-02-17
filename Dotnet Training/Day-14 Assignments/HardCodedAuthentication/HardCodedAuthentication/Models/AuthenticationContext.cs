using Microsoft.EntityFrameworkCore;

namespace HardCodedAuthentication.Models
{
    public class AuthenticationContext:DbContext
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
