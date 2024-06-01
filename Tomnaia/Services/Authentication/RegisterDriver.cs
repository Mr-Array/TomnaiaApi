using System.ComponentModel.DataAnnotations;

namespace Tomnaia.Services.Authentication
{
    public class RegisterDriver
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

            [Required]
        public string NationalPhoto { get; set; }
        [Required]
        public string NationalId { get; set; }
        [Required]
        public string LicensePhoto { get; set; }
        [Required]
        public string DriverLicenseNumber { get; set; }
    }
}
