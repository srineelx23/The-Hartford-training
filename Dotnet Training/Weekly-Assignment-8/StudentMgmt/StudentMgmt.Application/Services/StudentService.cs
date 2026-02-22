using StudentMgmt.Application.Interfaces.Repositories;
using StudentMgmt.Application.Interfaces.Services;
using StudentMgmt.Domain.Entities;

namespace StudentMgmt.Application.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }
        public async Task<Student> RegisterStudentAsync(Student student)
        {
            if(student.Gender!="Male" && student.Gender != "Female")
            {
                throw new ArgumentException("Gender must be Male or Female");
            }
            return await _repo.RegisterStudentAsync(student);
        }
    }
}
