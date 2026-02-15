namespace Weekly_Assignment_7.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        public int? GradeId { get; set; }
        public Grade? Grade { get; set; }
    }
}
