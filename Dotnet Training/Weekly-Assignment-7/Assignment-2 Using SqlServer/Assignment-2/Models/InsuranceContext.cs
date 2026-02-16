using Microsoft.EntityFrameworkCore;

namespace Assignment_2.Models
{
    public class InsuranceContext:DbContext
    {
        public InsuranceContext(DbContextOptions<InsuranceContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Policies> Policies { get; set; }
    }
}
