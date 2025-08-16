using System.ComponentModel.DataAnnotations;

namespace FamilyOrganizer.Server.Contracts
{
    public class RegisterRequest
    {
        [Required, EmailAddress] 
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(3), MaxLength(32)] 
        public string Username { get; set; } = string.Empty;

        [Required, MinLength(6), MaxLength(64)] 
        public string Password { get; set; } = string.Empty;
    }

    public class LoginRequest
    {
        [Required] public string Email { get; set; } = string.Empty;
        [Required] public string Password { get; set; } = string.Empty;
    }

    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;
        public object User { get; set; } = default!;
    }
}
