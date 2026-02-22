using Microsoft.AspNetCore.Http;

namespace StudentMgmt.Application.DTOs.StudyMaterials
{
    public class UpdateMaterialDTO
    {
        public IFormFile File { get; set; }
        public string? Title { get; set; }
    }
}
