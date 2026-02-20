using StudentMgmt.Models;

namespace StudentMgmt.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> AddStudentAsync(Student student);
    }
}
