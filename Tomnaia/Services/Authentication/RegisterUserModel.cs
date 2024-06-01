using System.ComponentModel.DataAnnotations;

public class RegisterUserModel
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Compare("Password")]
    [Required]
    public string ConfirmPassowrd { get; set; }
    [Required]
   
    // Driver specific properties
    public string? NationalPhoto { get; set; }
    public string? NationalId { get; set; }
    public string? LicensePhoto { get; set; }
    public string? DriverLicenseNumber { get; set; }
    public DateTime? ExpirDate { get; set; }

    // Other common properties
    public string? ProfilePicture { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }

    public AccountType AccountType { get; set; }

}
