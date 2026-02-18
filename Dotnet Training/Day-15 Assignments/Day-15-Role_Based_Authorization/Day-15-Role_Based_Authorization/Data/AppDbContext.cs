using Day_15_Role_Based_Authorization.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_15_Role_Based_Authorization.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<User> Users => Set<User>();
    }
}
