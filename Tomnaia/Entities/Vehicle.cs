using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tomnaia.Consts;

namespace Tomnaia.Entities
{
    public class Vehicle
    {
        [Key]
        public string VehicleId { get; set; }
        public int Capacity { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Model { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public ConstsVehicles VehicleType { get; set; }
        public string Photolicense { get; set; }
        public string PhotoVehicle { get; set; }
        public string LicenseStatus { get; set; }
      
        [Required]
        public string DriverId { get; set; }

        [ForeignKey(nameof(DriverId))]
        public Driver Driver { get; set; }

        public ICollection<Ride>? Rides { get; set; } = new List<Ride>();
    }
}
