using System.ComponentModel.DataAnnotations;

namespace sell_movie.Secure.Models
{
    public class LoginModels
    {
        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string Passwords { get; set; } = string.Empty;
    }
}
