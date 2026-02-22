using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentMgmt.Domain.Entities
{
    public class Student
    {
        [Key]
        [JsonIgnore]
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateOnly EnrollmentDate { get; set; }
        //[JsonIgnore]
        public ICollection<StudentFeedback>? Feedbacks { get; set; }
    }

}
