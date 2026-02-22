using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentMgmt.Application.Interfaces.Services;

namespace StudentMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly IStudyMaterialService _studymaterialService;
        public StudentController(IStudentService service, IStudyMaterialService materialService)
        {
            _service = service;
            _studymaterialService = materialService;
        }
        //[HttpPost]
        //[Route("register")]
        //public async Task<IActionResult> RegisterStudent([FromBody] Student student)
        //{
        //    try
        //    {
        //        var addedStudent = await _service.RegisterStudentAsync(student);
        //        return StatusCode(201, addedStudent);
        //    }
        //    catch(ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [HttpGet("materials")]
        public async Task<IActionResult> GetAllMaterials()
        {
            var materials = await _studymaterialService.GetAllMaterialsAsync();

            var result = materials.Select(m => new
            {
                m.StudyMaterialId,
                m.Title,
                m.FilePath,
                m.UploadedAt,
                TrainerName = m.Trainer != null
                    ? m.Trainer.FirstName + " " + m.Trainer.LastName
                    : "Trainer Deleted"
            });

            return Ok(result);
        }

    }
}
