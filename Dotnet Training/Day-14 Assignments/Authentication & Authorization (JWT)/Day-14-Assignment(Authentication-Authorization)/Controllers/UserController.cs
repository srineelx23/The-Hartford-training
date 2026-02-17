using Day_14_Assignment_Authentication_Authorization_.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_14_Assignment_Authentication_Authorization_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly AuthenticationContext _context;
        public UserController(AuthenticationContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult UserRegister(UserDTO userDto)
        {
            var result=_context.Users.FirstOrDefault(u=>u.Email == userDto.Email);
            if (result != null)
            {
                return BadRequest("User already exists");
            }
            User newUser = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return Ok("User registered successfully");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult UserLogin(LoginDTO loginDTO)
        {
            var result = _context.Users.FirstOrDefault(u => u.Email == loginDTO.Email && u.Password == loginDTO.Password);
            if (result == null)
            {
                return BadRequest("User Does not Exist");
            }
            return Ok("Login Successfull");
        }
    }
}
