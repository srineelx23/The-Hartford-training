using Microsoft.AspNetCore.Http;

namespace StudentMgmt.Application.DTOs.StudyMaterials
{
    public class UploadMaterialDTO
    {
        public IFormFile File { get; set; }
        public string Title { get; set; }
        public int TrainerId { get; set; }
    }
}
