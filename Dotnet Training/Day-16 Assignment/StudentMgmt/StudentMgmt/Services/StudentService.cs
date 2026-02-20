using StudentMgmt.Models;
using StudentMgmt.Repository;

namespace StudentMgmt.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _repo.GetAllStudentsAsync();
        }
        public async Task<Student> AddStudentAsync(Student student)
        {
            if(student.Gender!="Male" && student.Gender != "Female")
            {
                throw new ArgumentException("Gender must be Male or Female");
            }
            return await _repo.AddStudentAsync(student);
        }
    }
}
