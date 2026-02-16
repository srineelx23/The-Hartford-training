using System.ComponentModel.DataAnnotations;

namespace Assignment_2.Models
{
    public class Policies
    {
        [Key]
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
        public int PolicyTerm { get; set; }
    }
}
