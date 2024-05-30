using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tomnaia.Consts;

namespace Tomnaia.Entities
{
    public class Driver 
    {

        [Key]
        public string DriverId { get; set; } =  Guid.NewGuid().ToString();
        //[Required]
        //public string FirstName { get; set; }
        //[Required]
        //public string LastName { get; set; }
        public bool IsDeleted { get; set; } = false;
        [Required]
        public string NationalPhoto { get; set; }
        [Required]
        public string NationalId { get; set; }
        [Required]
        public string LicensePhoto { get; set; }
        [Required]
        public string DriverLicenseNumber { get; set; }


        //public string? Country { get; set; }

        //public string? City { get; set; }

        //public string? Street { get; set; }

        public string VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; set; }
        //public string LicenseNumberVehicle { get; set; }
        //[ForeignKey("Account")]
        //public string? AccountId { get; set; }
        //public User? Account { get; set; }
        public DateTime expirDate { get; set; }
     
        //public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        //public ICollection<Ride> Rides { get; set; } = new List<Ride>();
    }
}
