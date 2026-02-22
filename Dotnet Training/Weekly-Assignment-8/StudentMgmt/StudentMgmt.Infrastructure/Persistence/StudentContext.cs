using Microsoft.EntityFrameworkCore;
using StudentMgmt.Domain.Entities;

namespace StudentMgmt.Infrastructure.Persistence
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<StudentFeedback> StudentFeedback { get; set; }
        public DbSet<StudyMaterial> StudyMaterials { get; set; }
        public DbSet<Admin> Admins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudyMaterial>()
                .HasOne(sm => sm.Trainer)
                .WithMany(t => t.StudyMaterials)
                .HasForeignKey(sm => sm.TrainerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
