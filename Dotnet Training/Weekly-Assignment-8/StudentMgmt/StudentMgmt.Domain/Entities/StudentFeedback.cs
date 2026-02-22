using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentMgmt.Domain.Entities
{
    public class StudentFeedback
    {
        [Key]
        public int FeedbackId { get; set; }
        [Required]
        public string Feedback { get; set; }
        [Required]
        public int StudentId { get; set; }
        [JsonIgnore]    
        public Student? Student { get; set; }
        [Required]
        public int TrainerId { get; set; }
        public string? TrainerName { get; set; }
        [JsonIgnore]
        public Trainer? Trainer { get; set; }
        public DateOnly FeedbackDate { get; set; }
    }
}
