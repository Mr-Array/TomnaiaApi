using System.ComponentModel.DataAnnotations;

namespace Tomnaia.Services.Authentication
{
    public class ChangePassword
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; }
    }

}
