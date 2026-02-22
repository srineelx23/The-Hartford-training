using StudentMgmt.Application.DTOs.StudentDTOs;
using StudentMgmt.Application.DTOs.TrainerDTOs;
using StudentMgmt.Domain.Entities;
using StudentMgmt.DTOs.StudentDTOs;

namespace StudentMgmt.Application.Interfaces.Repositories
{
    public interface IAdminRepository
    {
        public Task<StudentReadDTO> GetStudentByIdAsync(int trainerId);
        public Task<Trainer> GetTrainerByIdAsync(int trainerId);
        public Task<IEnumerable<StudentReadDTO>> GetAllStudentsAsync();
        public Task<IEnumerable<TrainerReadDTO>> GetAllTrainersAsync();
        public Task<Student> UpdateStudentDetailsAsync(int studentId, UpdateStudentDTO updatedStudent);
        public Task<Trainer> UpdateTrainerDetailsAsync(int trainerId, UpdateTrainerDTO updatedTrainer);
        public Task<Student> DeleteStudentByIdAsync(int studentId);
        public Task<Trainer> DeleteTrainerByIdAsync(int trainerId);
    }
}
