using Microsoft.EntityFrameworkCore;
using StudentMgmt.Application.DTOs.StudyMaterials;
using StudentMgmt.Application.Interfaces.Repositories;
using StudentMgmt.Domain.Entities;
using StudentMgmt.Infrastructure.Persistence;

namespace StudentMgmt.Infrastructure.Repositories
{
    public class StudyMaterialRepository:IStudyMaterialRepository
    {
        private readonly StudentContext _context;

        public StudyMaterialRepository(StudentContext context)
        {
            _context = context;
        }

        public async Task<StudyMaterial> UploadMaterialAsync(UploadMaterialDTO dto)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/materials");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var uniqueFileName = Guid.NewGuid().ToString() +
                                 Path.GetExtension(dto.File.FileName);

            var fullPath = Path.Combine(folderPath, uniqueFileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await dto.File.CopyToAsync(stream);
            }

            var material = new StudyMaterial
            {
                Title = dto.Title,
                FilePath = "/materials/" + uniqueFileName,
                UploadedAt = DateTime.UtcNow,
                TrainerId = dto.TrainerId
            };

            _context.StudyMaterials.Add(material);
            await _context.SaveChangesAsync();

            return material;
        }

        public async Task<StudyMaterial> UpdateMaterialAsync(int materialId, UpdateMaterialDTO dto)
        {
            var material = await _context.StudyMaterials
                .FirstOrDefaultAsync(m => m.StudyMaterialId == materialId);

            if (material == null)
                throw new Exception("Material not found");

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/materials");

            // Delete old file
            if (!string.IsNullOrEmpty(material.FilePath))
            {
                var oldFileFullPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    material.FilePath.TrimStart('/'));

                if (File.Exists(oldFileFullPath))
                    File.Delete(oldFileFullPath);
            }

            if (dto.File != null && dto.File.Length > 0)
            {
                var uniqueFileName = Guid.NewGuid().ToString() +
                                     Path.GetExtension(dto.File.FileName);

                var newFullPath = Path.Combine(folderPath, uniqueFileName);

                using (var stream = new FileStream(newFullPath, FileMode.Create))
                {
                    await dto.File.CopyToAsync(stream);
                }

                material.FilePath = "/materials/" + uniqueFileName;
            }

            if (!string.IsNullOrEmpty(dto.Title))
                material.Title = dto.Title;

            await _context.SaveChangesAsync();

            return material;
        }
        public async Task<bool> DeleteMaterialAsync(int materialId)
        {
            var material = await _context.StudyMaterials
                .FirstOrDefaultAsync(m => m.StudyMaterialId == materialId);

            if (material == null)
                return false;

            // Delete physical file
            if (!string.IsNullOrEmpty(material.FilePath))
            {
                var fullPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    material.FilePath.TrimStart('/'));

                if (File.Exists(fullPath))
                    File.Delete(fullPath);
            }

            _context.StudyMaterials.Remove(material);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<List<StudyMaterial>> GetAllMaterialsAsync()
        {
            return await _context.StudyMaterials
                .Include(m => m.Trainer)
                .ToListAsync();
        }

        public async Task<List<StudyMaterial>> GetMaterialsByTrainerIdAsync(int trainerId)
        {
            return await _context.StudyMaterials
                .Include(m => m.Trainer)
                .Where(m => m.TrainerId == trainerId)
                .ToListAsync();
        }

    }
}
