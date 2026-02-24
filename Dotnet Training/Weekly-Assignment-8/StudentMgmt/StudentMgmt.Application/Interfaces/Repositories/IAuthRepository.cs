using StudentMgmt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentMgmt.Application.DTOs.RegisterLoginDTO.AuthDto;

namespace StudentMgmt.Application.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<bool> StudentEmailExists(string email);
        Task<bool> TrainerEmailExists(string email);
        Task<bool> AdminEmailExists(string email);

        Task AddStudent(Student dto);
        Task AddTrainer(Trainer dto);
        Task AddAdmin(Admin dto);

        // LOGIN
        Task<Student?> GetStudentByEmail(string email);
        Task<Trainer?> GetTrainerByEmail(string email);
        Task<Admin?> GetAdminByEmail(string email);
        Task<Student?> UpdateStudentPassword(Student student);
        Task<Trainer?> UpdateTrainerPassword(Trainer trainer);  
    }
}
