using Microsoft.EntityFrameworkCore;

namespace Weekly_Assignment_7.Models
{
    public class SchoolContext:DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
