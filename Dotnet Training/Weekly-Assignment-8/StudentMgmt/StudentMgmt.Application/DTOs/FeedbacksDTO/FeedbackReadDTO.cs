namespace StudentMgmt.Application.DTOs.FeedbacksDTO
{
    public class FeedbackReadDTO
    {
        public int FeedbackId { get; set; }
        public string Feedback { get; set; }
        public DateOnly FeedbackDate { get; set; }
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
    }
}
