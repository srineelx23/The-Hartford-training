using System.ComponentModel.DataAnnotations;

namespace StudentMgmt.Domain.Entities
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
