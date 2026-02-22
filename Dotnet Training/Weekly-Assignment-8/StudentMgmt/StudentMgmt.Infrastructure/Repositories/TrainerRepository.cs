//using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentMgmt.Application.DTOs.FeedbacksDTO;
using StudentMgmt.Application.DTOs.StudentDTOs;
using StudentMgmt.Application.Interfaces.Repositories;
using StudentMgmt.Domain.Entities;
using StudentMgmt.DTOs.StudentDTOs;
using StudentMgmt.Infrastructure.Persistence;

namespace StudentMgmt.Infrastructure.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly StudentContext _context; 
        public TrainerRepository(StudentContext context)
        {
            _context = context;
        }
        public async Task<StudentReadDTO> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students
        .Where(s => s.StudentId == id)
        .Select(s => new StudentReadDTO
        {
            StudentId = s.StudentId,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Email = s.Email,
            Age = s.Age,
            Gender = s.Gender,
            EnrollmentDate = s.EnrollmentDate,

            Feedbacks = s.Feedbacks.Select(f => new FeedbackReadDTO
            {
                FeedbackId = f.FeedbackId,
                Feedback = f.Feedback,
                FeedbackDate = f.FeedbackDate,
                TrainerId = f.TrainerId,
                TrainerName= f.TrainerName
            }).ToList()
        })
        .FirstOrDefaultAsync();
            return student;
        }
        public async Task<Trainer> GetTrainerByIdAsync(int id)
        {
            return await _context.Trainers.FindAsync(id);
        }
        public async Task<IEnumerable<StudentReadDTO>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Select(s => new StudentReadDTO
                {
                    StudentId = s.StudentId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                    Age = s.Age,
                    Gender = s.Gender,
                    EnrollmentDate = s.EnrollmentDate,

                    Feedbacks = s.Feedbacks.Select(f => new FeedbackReadDTO
                    {
                        FeedbackId = f.FeedbackId,
                        Feedback = f.Feedback,
                        FeedbackDate = f.FeedbackDate,
                        TrainerId = f.TrainerId,
                        TrainerName= f.Trainer.FirstName + " " + f.Trainer.LastName
                    }).ToList()
                })
                .ToListAsync();
        }
        public async Task<Trainer> RegisterTrainerAsync(Trainer trainer)
        {
            await _context.Trainers.AddAsync(trainer);
            await _context.SaveChangesAsync();
            return trainer;
        }
        public async Task<Student> UpdateStudentDetailsAsync(int studentId, UpdateStudentDTO dto)
        {
            var student = await _context.Students.FindAsync(studentId);

            if (student == null)
                throw new ArgumentException("Student not found");
            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;
            student.Email = dto.Email;
            student.Age = dto.Age;
            student.Gender = dto.Gender;
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Student> DeleteStudentByIdAsync(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<StudentFeedback> AddStudentFeedbackAsync(StudentFeedback feedback)
        {
           _context.StudentFeedback.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }
    }
    }
