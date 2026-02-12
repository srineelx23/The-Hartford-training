using System.ComponentModel.DataAnnotations;

namespace Day_11Assignments.DTOs
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        // Navigation property (One-to-Many relationship)
        public ICollection<ProductDTO>? Products { get; set; }
    }
}
