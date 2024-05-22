using System.ComponentModel.DataAnnotations;

namespace Tomnaia.Services.Authentication
{
    public class ResetPassword
    {
        [Required]
        public string Email { get; set; }
        public string Token { get; set; }
        [Required]

        public string NewPassword { get; set; }
        [Required]

        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
