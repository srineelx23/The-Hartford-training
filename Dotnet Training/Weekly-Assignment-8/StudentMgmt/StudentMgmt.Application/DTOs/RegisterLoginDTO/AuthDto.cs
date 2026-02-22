namespace StudentMgmt.Application.DTOs.RegisterLoginDTO
{
    public class AuthDto
    {
        public record RegisterDto(string Email, string Password, string Role);
        public record LoginDto(string Email, string Password);
        public record AuthResultDto(string Token, string Email, string Role);
    }
}
