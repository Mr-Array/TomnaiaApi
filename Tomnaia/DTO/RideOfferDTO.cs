using System.ComponentModel.DataAnnotations.Schema;
using Tomnaia.Consts;
using Tomnaia.Entities;

namespace Tomnaia.DTO
{
    public class RideOfferDTO
    {
        public string RideOfferId { get; set; }

        public string DriverId { get; set; }

        public string RideRequestId { get; set; }

        public StatusRide Status { get; set; } // "sent", "cancelled", "accepted", "rejected"
    }
}
