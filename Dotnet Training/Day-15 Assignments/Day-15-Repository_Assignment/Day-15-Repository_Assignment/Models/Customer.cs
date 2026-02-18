using System.ComponentModel.DataAnnotations;

namespace Day_15_Repository_Assignment.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public ICollection<Policy>? Policies { get; set; }
    }
}
