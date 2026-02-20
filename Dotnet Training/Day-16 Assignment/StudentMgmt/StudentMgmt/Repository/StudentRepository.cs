using Microsoft.EntityFrameworkCore;
using StudentMgmt.Data;
using StudentMgmt.Models;

namespace StudentMgmt.Repository
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
        public async Task<Student> AddStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
