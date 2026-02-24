using StudentMgmt.Domain.Entities;
using static StudentMgmt.Application.DTOs.RegisterLoginDTO.AuthDto;

namespace StudentMgmt.Application.Interfaces.Services
{
    public interface IAuthService
    {
        // REGISTER
        Task RegisterStudent(Student dto);
        Task RegisterTrainer(Trainer dto);
        Task RegisterAdmin(Admin dto);

        // LOGIN
        Task<AuthResultDto> LoginStudent(LoginDto dto);
        Task<AuthResultDto> LoginTrainer(LoginDto dto);
        Task<AuthResultDto> LoginAdmin(LoginDto dto);
        Task UpdateStudentPassword(string email,string password);
        Task UpdateTrainerPassword(string email,string password);
    }
}