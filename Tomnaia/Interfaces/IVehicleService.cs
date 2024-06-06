using Tomnaia.DTO;

namespace Tomnaia.Interfaces
{
    public interface IVehicleService
    { 

        Task<IEnumerable<VehicleDto>> GetVehiclesAsync();
    Task<VehicleDto> GetVehicleByIdAsync(string vehicleId);
    Task<VehicleAddDto> CreateVehicleAsync(VehicleAddDto vehicleAddDto);
    Task<bool> UpdateVehicleAsync(string vehicleId, VehicleUpdateDto vehicleUpdateDto);
    Task<bool> DeleteVehicleAsync(string vehicleId);
    Task<IEnumerable<VehicleDto>> GetVehiclesByDriverIdAsync(string driverId);
}
}
