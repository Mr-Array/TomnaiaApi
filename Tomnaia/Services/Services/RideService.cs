using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tomnaia.Data;
using Tomnaia.DTO;
using Tomnaia.Entities;
using Tomnaia.Interfaces;

namespace Tomnaia.Services.Services
{
    public class RideService : IRideService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RideService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RideDto>> GetRidesAsync()
        {
            var rides = await _context.Rides
                                     // .Include(r => r.Rider)    // Include Rider navigation property
                                      .Include(r => r.Passenger) // Include Passenger navigation property
                                      .Include(r => r.Vehicle)
                                      //.Include(r => r.PickupLocation)
                                     // .Include(r => r.RequestTime)
                                     //// .Include(r => r.DropoffLocation)
                                      .Include(r => r.Reviews)
                                      //.Include(r => r.RideId)
                                      //.Include(r => r.PassengerId)
                                      //.Include(r => r.Fare)
                                      //.Include(r => r.VehicleId)
                                      //.Include(r => r.StartTime)
                                      //.Include(r => r.EndTime)
                                      
                                      .ToListAsync();
            return _mapper.Map<IEnumerable<RideDto>>(rides);
        }

        public async Task<RideDto> GetRideByIdAsync(string rideId)
        {
            var ride = await _context.Rides
                                    .Include(r => r.Vehicle)    // Include Rider navigation property
                                     .Include(r => r.Passenger) // Include Passenger navigation property
                                      .Include(r => r.Reviews)
                                     .FirstOrDefaultAsync(r => r.RideId == rideId);
            if (ride == null)
            {
                return null;
            }
            return _mapper.Map<RideDto>(ride);
        }

        public async Task<RideDto> CreateRideAsync(RideDto rideDto)
        {
            var ride = _mapper.Map<Ride>(rideDto);
            _context.Rides.Add(ride);
            await _context.SaveChangesAsync();
            return _mapper.Map<RideDto>(ride);
        }

        public async Task<bool> UpdateRideAsync(RideDto rideDto)
        {
            var ride = await _context.Rides.FindAsync(rideDto.RideId);
            if (ride == null)
            {
                return false;
            }

            _mapper.Map(rideDto, ride);
            _context.Rides.Update(ride);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRideAsync(string rideId)
        {
            var ride = await _context.Rides.FindAsync(rideId);
            if (ride == null)
            {
                return false;
            }

            _context.Rides.Remove(ride);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<RideDto>> GetRidesByDriverIdAsync(string driverId)
        {
            var rides = await _context.Rides
                                      .Where(r => r.PassengerId == driverId)
                                      .Include(r => r.Vehicle)    // Include Vehicle navigation property
                                     .Include(r => r.Passenger) // Include Passenger navigation property
                                      .Include(r => r.Reviews) // Include Reviews navigation property
                                      .ToListAsync();
            return _mapper.Map<IEnumerable<RideDto>>(rides);
        }
    }
}