using System.ComponentModel.DataAnnotations;

namespace Tomnaia.Entities
{
    public class RidePassenger
    {
        
        public string RideId { get; set; }
        public Ride Ride { get; set; }

        
        public string PassengerId { get; set; }
        public Passenger Passenger { get; set; }
    }
}
