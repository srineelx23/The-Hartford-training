using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentMgmt.Application.DTOs.StudentDTOs;
using StudentMgmt.Application.DTOs.StudyMaterials;
using StudentMgmt.Application.Interfaces.Services;
using StudentMgmt.Domain.Entities;

namespace StudentMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Trainer")]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _service;
        private readonly IStudyMaterialService _studyMaterialService;
        public TrainerController(ITrainerService service, IStudyMaterialService studyMaterialService)
        {
            _service = service;
            _studyMaterialService = studyMaterialService;
        }
        [HttpPost]
        [Route("RegisterTrainer")]
        public async Task<IActionResult> RegisterTrainer([FromBody] Trainer trainer)
        {
            try
            {
                var res = await _service.RegisterTrainerAsync(trainer);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var res = await _service.GetAllStudentsAsync();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("students/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var res = await _service.GetStudentByIdAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("students/{id}")]
        public async Task<IActionResult> UpdateStudentDetails(int id, [FromBody] UpdateStudentDTO updatedStudent)
        {
            try
            {
                var res = await _service.UpdateStudentDetailsAsync(id, updatedStudent);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("AddStudentFeedback")]
        public async Task<IActionResult> AddStudentFeedback([FromBody] StudentFeedback feedback)
        {
            try
            {
                var res = await _service.AddStudentFeedbackAsync(feedback);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("students/{id}")]
        public async Task<IActionResult> DeleteStudentById(int id)
        {
            try
            {
                var res = await _service.DeleteStudentByIdAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("upload")]
        public async Task<IActionResult> UploadMaterial([FromForm] UploadMaterialDTO dto)
        {
            var material = await _studyMaterialService.UploadMaterialAsync(dto);

            return Ok(new
            {
                material.StudyMaterialId,
                material.Title,
                material.FilePath,
                material.UploadedAt,
                material.TrainerId
            });
        }

        [HttpPut("update/{materialId}")]
        public async Task<IActionResult> UpdateMaterial(int materialId, [FromForm] UpdateMaterialDTO dto)
        {
            var material = await _studyMaterialService.UpdateMaterialAsync(materialId, dto);

            return Ok(new
            {
                material.StudyMaterialId,
                material.Title,
                material.FilePath,
                material.UploadedAt
            });
        }
        [HttpGet("materials/{trainerId}")]
        public async Task<IActionResult> GetTrainerMaterials(int trainerId)
        {
            var materials = await _studyMaterialService
                .GetMaterialsByTrainerIdAsync(trainerId);

            return Ok(materials);
        }

    }
}
