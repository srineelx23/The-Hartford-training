using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HardCodedAuthentication.Models;
using HardCodedAuthentication.DTOs;

namespace HardCodedAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AuthenticationContext _context;
        public UserController(AuthenticationContext context)
        {
            _context = context;
        }
        [HttpPost]

        [Route("Register")]
        public IActionResult RegisterUser( UserDTO userDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var objuser= _context.Users.FirstOrDefault(u => u.Email == userDto.Email);
            if(objuser != null)
            {
                return BadRequest("Email already exists");
            }
            User newUser = new User
            {
                //UserId = _context.Users.Count() + 1,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();

            return Ok(newUser);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult LoginUser(LoginDTO userDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var objuser=_context.Users.FirstOrDefault(u=> u.Email == userDto.Email && u.Password == userDto.Password);
            if(objuser==null)
            {
                return BadRequest("Invalid email or password");
            }
            return Ok(objuser);
        }
    }
}
