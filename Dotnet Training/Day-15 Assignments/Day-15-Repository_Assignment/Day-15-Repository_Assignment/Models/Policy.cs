using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Day_15_Repository_Assignment.Models
{
    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
        public int PolicyTerm { get; set; }
        public int CustomerId { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; }
    }
}
