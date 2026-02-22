using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentMgmt.Application.Interfaces.Repositories;
using StudentMgmt.Domain.Entities;
using StudentMgmt.Infrastructure.Persistence;
using StudentMgmt.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentMgmt.Application.DTOs.RegisterLoginDTO.AuthDto;

namespace StudentMgmt.Infrastructure.Repositories
{
    internal class AuthRepository:IAuthRepository
    {
        private readonly StudentContext _context;

        public AuthRepository(StudentContext context)
        {
            _context = context;
        }

        // REGISTER

        public async Task<bool> StudentEmailExists(string email)
            => await _context.Students.AnyAsync(s => s.Email == email);

        public async Task<bool> TrainerEmailExists(string email)
            => await _context.Trainers.AnyAsync(t => t.Email == email);

        public async Task<bool> AdminEmailExists(string email)
            => await _context.Admins.AnyAsync(a => a.Email == email);

        public async Task AddStudent(Student dto)
        {
            _context.Students.Add(dto);
            await _context.SaveChangesAsync();
        }

        public async Task AddTrainer(Trainer dto)
        {
            _context.Trainers.Add(dto);
            await _context.SaveChangesAsync();
        }

        public async Task AddAdmin(Admin dto)
        {
            _context.Admins.Add(dto);
            await _context.SaveChangesAsync();
        }

        // LOGIN

        public async Task<Student?> GetStudentByEmail(string email)
            => await _context.Students
                .FirstOrDefaultAsync(s => s.Email == email);

        public async Task<Trainer?> GetTrainerByEmail(string email)
            => await _context.Trainers
                .FirstOrDefaultAsync(t => t.Email == email);

        public async Task<Admin?> GetAdminByEmail(string email)
            => await _context.Admins
                .FirstOrDefaultAsync(a => a.Email == email);
    }
}
