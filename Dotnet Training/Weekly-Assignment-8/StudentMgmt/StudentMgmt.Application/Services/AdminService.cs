using StudentMgmt.Application.DTOs.StudentDTOs;
using StudentMgmt.Application.DTOs.TrainerDTOs;
using StudentMgmt.Application.Interfaces.Repositories;
using StudentMgmt.Application.Interfaces.Services;
using StudentMgmt.Domain.Entities;
using StudentMgmt.DTOs.StudentDTOs;

namespace StudentMgmt.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repo;
        public AdminService(IAdminRepository repo)
        {
            _repo = repo;
        }
        public async Task<StudentReadDTO> GetStudentByIdAsync(int studentId)
        {
            var res = await _repo.GetStudentByIdAsync(studentId);
            if (res == null)
            {
                throw new Exception("Student not found");
            }
            return res;
        }
        public async Task<Trainer> GetTrainerByIdAsync(int trainerId)
        {
            var res = await _repo.GetTrainerByIdAsync(trainerId);
            if (res == null)
            {
                throw new Exception("Trainer not found");
            }
            return res;
        }
        public async Task<IEnumerable<StudentReadDTO>> GetAllStudentsAsync()
        {
            var res = await _repo.GetAllStudentsAsync();
            if (res == null || !res.Any())
            {
                throw new Exception("No students found");
            }
            return res;
        }
        public async Task<IEnumerable<TrainerReadDTO>> GetAllTrainersAsync()
        {
            var res = await _repo.GetAllTrainersAsync();
            if (res == null || !res.Any())
            {
                throw new Exception("No trainers found");
            }
            return res;
        }
        public async Task<Student> UpdateStudentDetailsAsync(int studentId, UpdateStudentDTO updatedStudent)
        {
            var res = await _repo.GetStudentByIdAsync(studentId);
            if (res == null)
            {
                throw new Exception("Student not found");
            }
            return await _repo.UpdateStudentDetailsAsync(studentId, updatedStudent);
        }
        public async Task<Trainer> UpdateTrainerDetailsAsync(int trainerId, UpdateTrainerDTO updatedTrainer)
        {
            var res = await _repo.GetTrainerByIdAsync(trainerId);
            if (res == null)
            {
                throw new Exception("Trainer not found");
            }
            return await _repo.UpdateTrainerDetailsAsync(trainerId, updatedTrainer);
        }
        public async Task<Student> DeleteStudentByIdAsync(int studentId)
        {
            var res = await _repo.GetStudentByIdAsync(studentId);
            if (res == null)
            {
                throw new Exception("Student not found");
            }
            return await _repo.DeleteStudentByIdAsync(studentId);
        }
        public async Task<Trainer> DeleteTrainerByIdAsync(int trainerId)
        {
            var res = await _repo.GetTrainerByIdAsync(trainerId);
            if (res == null)
            {
                throw new Exception("Trainer not found");
            }
            return await _repo.DeleteTrainerByIdAsync(trainerId);
        }
    }
}
