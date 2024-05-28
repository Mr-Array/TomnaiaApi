using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Tomnaia.Consts;

namespace Tomnaia.Entities
{
    public class Vehicle
    {
        [Key]
        public string VehicleId { get; set; }
        public int Capacity { get; set; }
       
        public string Model { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string VehicleType { get; set; }
        public string Photolicense { get; set; }
        public string PhotoVehicle { get; set; }
        public string LicenseStatus { get; set; }
        public string DriverId { get; set; } = string.Empty;
        

    }
}
