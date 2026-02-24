//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using StudentMgmt.Application.Interfaces.Repositories;
using StudentMgmt.Application.Interfaces.Services;
using StudentMgmt.Domain.Entities;
using static StudentMgmt.Application.DTOs.RegisterLoginDTO.AuthDto;

namespace StudentMgmt.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwt;

        private readonly PasswordHasher<Student> _studentHasher = new();
        private readonly PasswordHasher<Trainer> _trainerHasher = new();
        private readonly PasswordHasher<Admin> _adminHasher = new();

        public AuthService(IAuthRepository authRepository, IJwtService jwt)
        {
            _authRepository = authRepository;
            _jwt = jwt;
        }

        // REGISTER

        public async Task RegisterStudent(Student dto)
        {
            if (await _authRepository.StudentEmailExists(dto.Email))
                throw new Exception("Email already exists.");

            dto.Password = _studentHasher.HashPassword(dto, dto.Password);
            await _authRepository.AddStudent(dto);
        }

        public async Task RegisterTrainer(Trainer dto)
        {
            if (await _authRepository.TrainerEmailExists(dto.Email))
                throw new Exception("Email already exists.");

            dto.password = _trainerHasher.HashPassword(dto, dto.password);
            await _authRepository.AddTrainer(dto);
        }

        public async Task RegisterAdmin(Admin dto)
        {
            if (await _authRepository.AdminEmailExists(dto.Email))
                throw new Exception("Email already exists.");

            dto.Password = _adminHasher.HashPassword(dto, dto.Password);
            await _authRepository.AddAdmin(dto);
        }

        // LOGIN

        public async Task<AuthResultDto> LoginStudent(LoginDto dto)
        {
            var student = await _authRepository.GetStudentByEmail(dto.Email);

            if (student == null)
                throw new Exception("Invalid credentials.");

            var result = _studentHasher.VerifyHashedPassword(
                student,
                student.Password,
                dto.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Invalid credentials.");

            var token = _jwt.GenerateToken(
                student.StudentId,
                student.FirstName,
                student.LastName,
                "Student");

            return new AuthResultDto(
                token,
                $"{student.FirstName} {student.LastName}",
                "Student");
        }

        public async Task<AuthResultDto> LoginTrainer(LoginDto dto)
        {
            var trainer = await _authRepository.GetTrainerByEmail(dto.Email);

            if (trainer == null)
                throw new Exception("Invalid credentials.");

            var result = _trainerHasher.VerifyHashedPassword(
                trainer,
                trainer.password,
                dto.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Invalid credentials.");

            var token = _jwt.GenerateToken(
                trainer.TrainerId,
                trainer.FirstName,
                trainer.LastName,
                "Trainer");

            return new AuthResultDto(
                token,
                $"{trainer.FirstName} {trainer.LastName}",
                "Trainer");
        }


        // LOGIN ADMIN
        public async Task<AuthResultDto> LoginAdmin(LoginDto dto)
        {
            var admin = await _authRepository.GetAdminByEmail(dto.Email);

            if (admin == null)
                throw new Exception("Invalid credentials.");

            var result = _adminHasher.VerifyHashedPassword(
                admin,
                admin.Password,
                dto.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Invalid credentials.");

            var token = _jwt.GenerateToken(
                admin.AdminId,
                admin.Email,
                "",
                "Admin");

            return new AuthResultDto(
                token,
                admin.Email,
                "Admin");
        }

        public async Task UpdateStudentPassword(string email, string password)
        {
            if (email == null) throw new ArgumentNullException("enter valid email");
            else if (password == null) throw new ArgumentNullException("Enter valid password");
            else
            {
                var res=await _authRepository.StudentEmailExists(email);
                if(res==true)
                {
                    var fetchedStudent=await _authRepository.GetStudentByEmail(email);
                    fetchedStudent.Password=_studentHasher.HashPassword(fetchedStudent,password);
                    await _authRepository.UpdateStudentPassword(fetchedStudent);
                }
            }
        }

        public async Task UpdateTrainerPassword(string email,string password)
        {
            if (email == null) throw new ArgumentException("enter valid student email");
            else if(password == null) throw new ArgumentNullException("enter valid Password");
            else
            {
                var fetchedTrainer=await _authRepository.GetTrainerByEmail(email);
                fetchedTrainer.password = _trainerHasher.HashPassword(fetchedTrainer,password);
                await _authRepository.UpdateTrainerPassword(fetchedTrainer);
            }
        }
    }
}