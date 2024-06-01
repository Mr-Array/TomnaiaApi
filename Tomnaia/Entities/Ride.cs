using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomnaia.Entities
{
    public class Ride
    {
        [Key]
        [Required]
        public string RideId { get; set; }
      
       
        [Required]
        public string PickupLocation { get; set; }
        [Required]
        public string DropoffLocation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Rider { get; set; }
        public double Fare { get; set; }
        public DateTime RequestTime { get; set; }

        //[Required]
        //public string DriverId { get; set; }

        //[ForeignKey(nameof(DriverId))]
        //public Driver Driver { get; set; }

        [Required]
        public string PassengerId { get; set; }

        [ForeignKey(nameof(PassengerId))]
        public Passenger Passenger { get; set; }

        [Required]
        public string VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; set; }

        //public ICollection<RidePassenger> RidePassengers { get; set; } = new List<RidePassenger>();
        //public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
