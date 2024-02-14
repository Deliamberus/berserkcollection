using System.ComponentModel.DataAnnotations;

namespace BerserkCollection.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        public string? City { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}