using System.ComponentModel.DataAnnotations;

namespace Assignment_2.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public ICollection<Policies>? Policies { get; set; }
    }
}
