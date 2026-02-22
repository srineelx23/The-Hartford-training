using StudentMgmt.Application.DTOs.StudyMaterials;
using StudentMgmt.Application.Interfaces.Repositories;
using StudentMgmt.Application.Interfaces.Services;
using StudentMgmt.Domain.Entities;

namespace StudentMgmt.Application.Services
{
    public class StudyMaterialService: IStudyMaterialService
    {
        private readonly IStudyMaterialRepository _repository;

        public StudyMaterialService(IStudyMaterialRepository repository)
        {
            _repository = repository;
        }

        public async Task<StudyMaterial> UploadMaterialAsync(UploadMaterialDTO dto)
        {
            if (dto.File == null || dto.File.Length == 0)
                throw new Exception("No file uploaded");

            return await _repository.UploadMaterialAsync(dto);
        }

        public async Task<StudyMaterial> UpdateMaterialAsync(int materialId, UpdateMaterialDTO dto)
        {
            return await _repository.UpdateMaterialAsync(materialId, dto);
        }
        public async Task<bool> DeleteMaterialAsync(int materialId)
        {
            return await _repository.DeleteMaterialAsync(materialId);
        }
        public async Task<List<StudyMaterial>> GetAllMaterialsAsync()
        {
            return await _repository.GetAllMaterialsAsync();
        }

        public async Task<List<StudyMaterial>> GetMaterialsByTrainerIdAsync(int trainerId)
        {
            return await _repository.GetMaterialsByTrainerIdAsync(trainerId);
        }

    }
}
