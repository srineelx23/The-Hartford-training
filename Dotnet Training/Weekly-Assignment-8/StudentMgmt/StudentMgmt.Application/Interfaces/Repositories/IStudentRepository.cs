using StudentMgmt.Domain.Entities;

namespace StudentMgmt.Application.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> RegisterStudentAsync(Student student);
    }
}
