using System.ComponentModel.DataAnnotations;

namespace Tomnaia.Entities
{
    public class Ride
    {
        [Key]
        [Required]
        public string RideId { get; set; }
        public string UserId { get; set; }
        public string DriverId { get; set; }
        public string VehicleId { get; set; }
        [Required]
        public string PickupLocation { get; set; }
        [Required]
        public string DropoffLocation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Rider { get; set; }
        public double Fare { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
