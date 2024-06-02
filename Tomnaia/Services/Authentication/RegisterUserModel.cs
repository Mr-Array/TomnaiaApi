using System.ComponentModel.DataAnnotations;

public class RegisterUserModel
{
    [Required(ErrorMessage = " Name Is Required")]
    [MinLength(3, ErrorMessage = "Name must be 3 char at least")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = " Name Is Required")]
    [MinLength(3, ErrorMessage = "Name must be 3 char at least")]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
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

    // Other common propertiess
    public string? ProfilePicture { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }

    public AccountType AccountType { get; set; }

}
