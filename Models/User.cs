using System.ComponentModel.DataAnnotations;

namespace Lab11_KazanovAlexandr.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
