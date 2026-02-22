using StudentMgmt.Application.DTOs.FeedbacksDTO;

namespace StudentMgmt.DTOs.StudentDTOs
{
    public class StudentReadDTO
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateOnly EnrollmentDate { get; set; }

        public List<FeedbackReadDTO> Feedbacks { get; set; }
    }
}
