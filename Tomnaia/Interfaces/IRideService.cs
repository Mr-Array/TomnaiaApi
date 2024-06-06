using Tomnaia.DTO;

namespace Tomnaia.Interfaces
{
    public interface IRideService
    {
        Task<IEnumerable<RideDto>> GetRidesAsync();
        Task<RideDto> GetRideByIdAsync(string rideId);
        Task<RideAddDto> CreateRideAsync(RideAddDto rideAddDto);
        Task<bool> UpdateRideAsync(string rideId , RideUpdateDto rideUpdateDto);
        Task<bool> DeleteRideAsync(string rideId);
        Task<IEnumerable<RideDto>> GetRidesByDriverIdAsync(string driverId);
    }
}
