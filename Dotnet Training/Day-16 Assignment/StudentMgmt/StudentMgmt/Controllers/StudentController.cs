using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMgmt.Services;

namespace StudentMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _service.GetAllStudentsAsync();
            return Ok(students);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Models.Student student)
        {
            try
            {
                var addedStudent = await _service.AddStudentAsync(student);
                return CreatedAtAction(nameof(GetAllStudents), new { id = addedStudent.StudentId }, addedStudent);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
