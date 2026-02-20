using StudentMgmt.Models;
namespace StudentMgmt.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> AddStudentAsync(Student student);
    }
}
