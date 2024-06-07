using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tomnaia.Consts;

namespace Tomnaia.Entities
{
    public class RideOffer
    {
        [Key]
        public string RideOfferId { get; set; }

        [ForeignKey("DriverId")]
        public Driver Driver { get; set; }
        public string DriverId { get; set; }

        [ForeignKey("RideRequestId")]
        public Ride RideRequest { get; set; }
        public string RideRequestId { get; set; }

        [Required]
        public StatusRide Status { get; set; } // "sent", "cancelled", "accepted", "rejected"
    }
}
