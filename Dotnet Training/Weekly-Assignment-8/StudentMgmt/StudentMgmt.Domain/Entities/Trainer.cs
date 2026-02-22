using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentMgmt.Domain.Entities
{
    public class Trainer
    {
        [Key]
        public int TrainerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string Gender { get; set; }
        [JsonIgnore]
        public ICollection<StudentFeedback>? Feedbacks { get; set; }
        [JsonIgnore]
        public ICollection<StudyMaterial>? StudyMaterials { get; set; }
    }
}
