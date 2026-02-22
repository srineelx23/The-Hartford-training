using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentMgmt.Application.DTOs.StudentDTOs;
using StudentMgmt.Application.DTOs.StudyMaterials;
using StudentMgmt.Application.DTOs.TrainerDTOs;
using StudentMgmt.Application.Interfaces.Services;

namespace StudentMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;
        private readonly IStudyMaterialService _studyMaterialService;
        public AdminController(IAdminService service,IStudyMaterialService studyMaterialService)
        {
            _service = service;
            _studyMaterialService = studyMaterialService;
        }
        [HttpGet("Students/{StudentId}")]
        public async Task<IActionResult> GetStudentByIdAsync(int StudentId)
        {
            try
            {
                var FetchedStudent = await _service.GetStudentByIdAsync(StudentId);
                return Ok(FetchedStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Trainers/{TrainerId}")]
        public async Task<IActionResult> GetTrainerByIdAsync(int TrainerId)
        {
            try
            {
                var FetchedTrainer = await _service.GetTrainerByIdAsync(TrainerId);
                return Ok(FetchedTrainer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Students")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            try
            {
                var FetchedStudents = await _service.GetAllStudentsAsync();
                return Ok(FetchedStudents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Trainers")]
        public async Task<IActionResult> GetAllTrainersAsync()
        {
            try
            {
                var FetchedTrainers = await _service.GetAllTrainersAsync();
                return Ok(FetchedTrainers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Students/Update/{UpdateStudentId}")]
        public async Task<IActionResult> UpdateStudentDetailsAsync(int UpdateStudentId, UpdateStudentDTO StudentDto)
        {
            try
            {
                var UpdatedStudent = await _service.UpdateStudentDetailsAsync(UpdateStudentId, StudentDto);
                return Ok(UpdatedStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Trainers/Update/{TrainerId}")]
        public async Task<IActionResult> UpdateTrainerDetailsAsync(int TrainerId, UpdateTrainerDTO TrainerDto)
        {
            try
            {
                var UpdatedTrainer = await _service.UpdateTrainerDetailsAsync(TrainerId, TrainerDto);
                return Ok(UpdatedTrainer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Students/Delete/{StudentId}")]
        public async Task<IActionResult> DeleteStudentById(int StudentId)
        {
            try
            {
                var DeletedStudent = await _service.DeleteStudentByIdAsync(StudentId);
                return Ok(DeletedStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Trainers/Delete/{TrainerId}")]
        public async Task<IActionResult> DeleteTrainerById(int TrainerId)
        {
            try
            {
                var DeletedTrainer = await _service.DeleteTrainerByIdAsync(TrainerId);
                return Ok(DeletedTrainer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
        [HttpDelete("materials/{materialId}")]
        public async Task<IActionResult> DeleteMaterial(int materialId)
        {
            var deleted = await _studyMaterialService.DeleteMaterialAsync(materialId);

            if (!deleted)
                return NotFound("Material not found");

            return Ok(new
            {
                message = "Material deleted successfully by admin"
            });
        }
        [HttpGet("materials")]
        public async Task<IActionResult> GetAllMaterials()
        {
            var materials = await _studyMaterialService.GetAllMaterialsAsync();

            return Ok(materials);
        }
    }
}
