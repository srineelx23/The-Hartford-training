using Microsoft.AspNetCore.Mvc;
using StudentMgmt.Domain.Entities;
using StudentMgmt.Application.Interfaces.Services;
using static StudentMgmt.Application.DTOs.RegisterLoginDTO.AuthDto;
using System.Reflection.Metadata.Ecma335;

namespace StudentMgmt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // -------- REGISTER --------

        [HttpPost("student/register")]
        public async Task<IActionResult> RegisterStudent(Student dto)
        {
            await _authService.RegisterStudent(dto);
            return Ok("Student registered successfully.");
        }

        [HttpPost("trainer/register")]
        public async Task<IActionResult> RegisterTrainer(Trainer dto)
        {
            await _authService.RegisterTrainer(dto);
            return Ok("Trainer registered successfully.");
        }

        [HttpPost("admin/register")]
        public async Task<IActionResult> RegisterAdmin(Admin dto)
        {
            await _authService.RegisterAdmin(dto);
            return Ok("Admin registered successfully.");
        }

        // -------- LOGIN --------

        [HttpPost("student/login")]
        public async Task<IActionResult> LoginStudent(LoginDto dto)
        {
            var result = await _authService.LoginStudent(dto);
            return Ok(result);
        }

        [HttpPost("trainer/login")]
        public async Task<IActionResult> LoginTrainer(LoginDto dto)
        {
            var result = await _authService.LoginTrainer(dto);
            return Ok(result);
        }

        [HttpPost("admin/login")]
        public async Task<IActionResult> LoginAdmin(LoginDto dto)
        {
            var result = await _authService.LoginAdmin(dto);
            return Ok(result);
        }
        [HttpPut("student/forgotpassword")]
        public async Task<IActionResult> UpdateStudentPassword(string email,string password)
        {
            try
            {
                await _authService.UpdateStudentPassword(email, password);
                return Ok("Student Updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("trainer/forgotpassword")]
        public async Task<IActionResult> UpdateTrainerPassword(string email,string password)
        {
            try
            {
                await _authService.UpdateTrainerPassword(email, password);
                return Ok("Trainer Updated succesfully");
            }
            catch(Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
