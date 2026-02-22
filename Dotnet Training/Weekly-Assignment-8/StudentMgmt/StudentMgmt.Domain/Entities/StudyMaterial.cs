namespace StudentMgmt.Domain.Entities
{
    public class StudyMaterial
    {
        public int StudyMaterialId { get; set; }

        public string Title { get; set; }

        public string FilePath { get; set; }   // Stored locally

        public DateTime UploadedAt { get; set; }

        public int? TrainerId { get; set; }   // nullable!

        public Trainer? Trainer { get; set; }
    }
}
