using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tomnaia.Data;
using Tomnaia.DTO;
using Tomnaia.Entities;
using Tomnaia.Interfaces;

namespace Tomnaia.Services.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VehicleService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehicleDto>> GetVehiclesAsync()
        {
            var vehicles = await _context.Vehicles.Include(v => v.Driver).ToListAsync();
            return _mapper.Map<IEnumerable<VehicleDto>>(vehicles);
        }

        public async Task<VehicleDto> GetVehicleByIdAsync(string vehicleId)
        {
            var vehicle = await _context.Vehicles.Include(v => v.Driver).FirstOrDefaultAsync(v => v.VehicleId == vehicleId);
            if (vehicle == null)
            {
                return null;
            }
            return _mapper.Map<VehicleDto>(vehicle);
        }

        public async Task<VehicleDto> CreateVehicleAsync(VehicleDto vehicleDto)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleDto);
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return _mapper.Map<VehicleDto>(vehicle);
        }

        public async Task<bool> UpdateVehicleAsync(string vehicleId, VehicleUpdateDto vehicleUpdateDto)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            if (vehicle == null)
            {
                return false;
            }

            _mapper.Map(vehicleUpdateDto, vehicle);
            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVehicleAsync(string vehicleId)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            if (vehicle == null)
            {
                return false;
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<VehicleDto>> GetVehiclesByDriverIdAsync(string driverId)
        {
            var vehicles = await _context.Vehicles.Where(v => v.DriverId == driverId).Include(v => v.Driver).ToListAsync();
            return _mapper.Map<IEnumerable<VehicleDto>>(vehicles);
        }
    }
}