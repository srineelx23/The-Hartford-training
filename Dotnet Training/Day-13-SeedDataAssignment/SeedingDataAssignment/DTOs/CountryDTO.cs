namespace SeedingDataAssignment.DTOs
{
    public class CountryDTO
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public List<StateDTO> States { get; set; }
    }
}
