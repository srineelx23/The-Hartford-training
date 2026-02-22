using Microsoft.EntityFrameworkCore;
using StudentMgmt.Application.Interfaces.Repositories;
using StudentMgmt.Domain.Entities;
using StudentMgmt.Infrastructure.Persistence;

namespace StudentMgmt.Infrastructure.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        private readonly StudentContext _context;
        public StudentRepository(StudentContext context) {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student> RegisterStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
