using System.ComponentModel.DataAnnotations;

namespace Tomnaia.Entities
{
    public class Ride
    {
        public int RideId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string PickupLocation { get; set; }

        [Required]
        public string DropoffLocation { get; set; }

        public DateTime RequestTime { get; set; }
    }
}
