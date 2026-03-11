using AuthService.Application.DTOs;
using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Services
{
    public class Authservice : IAuthService
    {
        private readonly IUserRepository repo;
        private readonly IJwtService jwt;

        public Authservice(IUserRepository repo, IJwtService jwt)
        {
            this.repo = repo;
            this.jwt = jwt;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            var user = new User
            {
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            await repo.CreateAsync(user);

            var token = jwt.GenerateToken(user.Email);

            return new AuthResponseDto
            {
                Email = user.Email,
                Token = token
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await repo.GetByEmailAsync(dto.Email);

            if (user == null ||
                !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            var token = jwt.GenerateToken(user.Email);

            return new AuthResponseDto
            {
                Email = user.Email,
                Token = token
            };
        }
    }
}
