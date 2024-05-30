using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Tomnaia.Consts;

namespace Tomnaia.Entities
{
    public class Driver : IdentityUser
    {
        [Key]
        public string DriverId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string NationalPhoto { get; set; }
        [Required]
        public string NationalId { get; set; }
        [Required]
        public string LicensePhoto { get; set; }
        [Required]
        public string DriverLicenseNumber { get; set; }
        public string? ProfilePicture { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public string VehicleId { get; set; }
        public string LicenseNumberVehicle { get; set; }
        //public Vehicle Vehicles { get; set; }
        public DateTime expirDate { get; set; }
        public Status Status { get; set; }
    }
}
