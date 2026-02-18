using Microsoft.EntityFrameworkCore;

namespace Day_15_Repository_Assignment.Models
{
    public class InsuranceContext:DbContext
    {
        public InsuranceContext(DbContextOptions<InsuranceContext> options): base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Policy> Policies { get; set; }
    }
}
