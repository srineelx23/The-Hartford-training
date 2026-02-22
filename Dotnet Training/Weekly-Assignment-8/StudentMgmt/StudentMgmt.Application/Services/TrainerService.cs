using StudentMgmt.DTOs.StudentDTOs;
using StudentMgmt.Domain.Entities;
using StudentMgmt.Application.DTOs.StudentDTOs;
using StudentMgmt.Application.Interfaces.Repositories;
using StudentMgmt.Application.Interfaces.Services;

namespace StudentMgmt.Application.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _repo;
        public TrainerService(ITrainerRepository repo)
        {
            _repo = repo;
        }
        public async Task<StudentReadDTO> GetStudentByIdAsync(int trainerId)
        {
            var res= await _repo.GetStudentByIdAsync(trainerId);
            if(res== null)
            {
                throw new Exception("Student not found");
            }
            return res;
        }
        public async Task<Trainer> RegisterTrainerAsync(Trainer trainer)
        {
            var res = await _repo.GetTrainerByIdAsync(trainer.TrainerId);
            if (res != null)
            {
                throw new Exception("Trainer already exists");
            }
            return await _repo.RegisterTrainerAsync(trainer);
        }
        public async Task<Student> UpdateStudentDetailsAsync(int studentId, UpdateStudentDTO updatedStudent)
        {
            var res = await _repo.GetStudentByIdAsync(studentId);
            return await _repo.UpdateStudentDetailsAsync(studentId, updatedStudent);
        }
        public async Task<StudentFeedback> AddStudentFeedbackAsync(StudentFeedback feedback)
        {
            var res= await _repo.GetStudentByIdAsync(feedback.StudentId);
            if(res== null)
            {
                throw new Exception("Student not found");
            }
            var res2= await _repo.GetTrainerByIdAsync(feedback.TrainerId);
            if(res2== null)
            {
                throw new Exception("Trainer not found");
            }
            feedback.TrainerName = res2.FirstName + " " + res2.LastName;
            return await _repo.AddStudentFeedbackAsync(feedback);
        }
        public async Task<IEnumerable<StudentReadDTO>> GetAllStudentsAsync()
        {
            var res= await _repo.GetAllStudentsAsync();
            if(res== null || !res.Any())
            {
                throw new Exception("No students found");
            }
            return res;
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
    }
    }
