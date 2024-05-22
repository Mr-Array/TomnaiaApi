using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Tomnaia.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
