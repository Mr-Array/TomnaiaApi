using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tomnaia.Consts;

namespace Tomnaia.Entities
{
    public class User : IdentityUser
    {
        //[Key]
        //[Required]
        //public string AccountId { get; set; }
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
        public string AccountType { get; set; }

        [ForeignKey("Passenger")]
        public string? PassengerId { get; set; }
        public Passenger? Passenger { get; set; }

        [ForeignKey("Driver")]
        public string? DriverIdId { get; set; }
        public Driver? Driver { get; set; }
        [ForeignKey("Adminstrator")]
        public string? AdminstratorId { get; set; }
        public Adminstrator? Adminstrator { get; set; }
    }
}
