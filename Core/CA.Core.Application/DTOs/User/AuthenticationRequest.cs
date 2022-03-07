using System.ComponentModel.DataAnnotations;

namespace CA.Core.Application.DTOs.User
{
    public class AuthenticationRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}