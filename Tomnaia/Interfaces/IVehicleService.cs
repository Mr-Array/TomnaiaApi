using Tomnaia.DTO;

namespace Tomnaia.Interfaces
{
    public interface IVehicleService
    { 

        Task<IEnumerable<VehicleDto>> GetVehiclesAsync();
    Task<VehicleDto> GetVehicleByIdAsync(string vehicleId);
    Task<VehicleDto> CreateVehicleAsync(VehicleDto vehicleDto);
    Task<bool> UpdateVehicleAsync(VehicleDto vehicleDto);
    Task<bool> DeleteVehicleAsync(string vehicleId);
    Task<IEnumerable<VehicleDto>> GetVehiclesByDriverIdAsync(string driverId);
}
}
