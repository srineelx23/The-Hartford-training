using StudentMgmt.Domain.Entities;

namespace StudentMgmt.Application.Interfaces.Services
{
    public interface IStudentService
    {
        Task<Student> RegisterStudentAsync(Student student);
    }
}
