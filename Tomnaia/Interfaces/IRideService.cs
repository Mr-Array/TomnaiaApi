using Tomnaia.DTO;

namespace Tomnaia.Interfaces
{
    public interface IRideService
    {
        Task<IEnumerable<RideDto>> GetRidesAsync();
        Task<RideDto> GetRideByIdAsync(string rideId);
        Task<RideDto> CreateRideAsync(RideDto rideDto);
        Task<bool> UpdateRideAsync(RideDto rideDto);
        Task<bool> DeleteRideAsync(string rideId);
        Task<IEnumerable<RideDto>> GetRidesByDriverIdAsync(string driverId);
    }
}
