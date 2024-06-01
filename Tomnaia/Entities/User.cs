using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tomnaia.Consts;

namespace Tomnaia.Entities
{
    public class User : IdentityUser
    {

        public AccountType AccountType { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string? ProfilePicture { get; set; }
        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Status Status { get; set; }

    }
}

public enum AccountType
{
    Passenger,
    Driver,
    Admin
}