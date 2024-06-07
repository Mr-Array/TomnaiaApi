using Tomnaia.DTO;

namespace Tomnaia.Interfaces
{
    public interface IRideOfferService
    {
        Task<IEnumerable<RideOfferDTO>> GetRidesOfferAsync();
        Task<RideOfferDTO> GetRideOfferByIdAsync(string rideOfferId);
        Task<RideOfferUpdateDto> CreateRideOfferAsync(RideOfferUpdateDto rideOfferAddDto);
        Task<bool> UpdateRideofferAsync(string rideOfferId, RideOfferUpdateDto rideOfferUpdateDto);
        Task<bool> DeleteRideOfferAsync(string rideOfferId);
        Task<IEnumerable<RideOfferDTO>> GetRidesOfferByDriverIdAsync(string driverId);
    }
}
