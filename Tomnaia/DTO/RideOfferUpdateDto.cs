using Tomnaia.Consts;

namespace Tomnaia.DTO
{
    public class RideOfferUpdateDto
    {
        public string DriverId { get; set; }

        public string RideRequestId { get; set; }

        public StatusRide Status { get; set; } // "sent", "cancelled", "accepted", "rejected"
    }
}
