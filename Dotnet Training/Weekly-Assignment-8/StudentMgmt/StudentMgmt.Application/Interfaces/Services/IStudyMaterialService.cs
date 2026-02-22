using StudentMgmt.Application.DTOs.StudyMaterials;
using StudentMgmt.Domain.Entities;

namespace StudentMgmt.Application.Interfaces.Services
{
    public interface IStudyMaterialService
    {
        Task<StudyMaterial> UploadMaterialAsync(UploadMaterialDTO dto);
        Task<StudyMaterial> UpdateMaterialAsync(int materialId, UpdateMaterialDTO dto);
        Task<bool> DeleteMaterialAsync(int materialId);
        Task<List<StudyMaterial>> GetAllMaterialsAsync();
        Task<List<StudyMaterial>> GetMaterialsByTrainerIdAsync(int trainerId);

    }
}
