using StudentMgmt.Application.DTOs.StudentDTOs;
using StudentMgmt.Domain.Entities;
using StudentMgmt.DTOs.StudentDTOs;

namespace StudentMgmt.Application.Interfaces.Services
{
    public interface ITrainerService
    {
            public Task<StudentReadDTO> GetStudentByIdAsync(int trainerId);
            public Task<Trainer> RegisterTrainerAsync(Trainer trainer);
            public Task<Student> UpdateStudentDetailsAsync(int studentId, UpdateStudentDTO updatedStudent);
            public Task<StudentFeedback> AddStudentFeedbackAsync(StudentFeedback feedback);
            public Task<IEnumerable<StudentReadDTO>> GetAllStudentsAsync();
            public Task<Student> DeleteStudentByIdAsync(int studentId);
    }
}
