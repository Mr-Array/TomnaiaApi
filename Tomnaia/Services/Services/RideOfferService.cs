using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tomnaia.Data;
using Tomnaia.DTO;
using Tomnaia.Entities;
using Tomnaia.Interfaces;

namespace Tomnaia.Services.Services
{
    public class RideOfferService : IRideOfferService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public RideOfferService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RideOfferDTO>> GetRidesOfferAsync()
        {
            var rides = await _context.RideOffers
                                      .Include(r => r.Driver)
                                     .Include(r => r.RideRequest)


                                      .ToListAsync();
            return _mapper.Map<IEnumerable<RideOfferDTO>>(rides);
        }

        public async Task<RideOfferDTO> GetRideOfferByIdAsync(string rideId)
        {
            var ride = await _context.RideOffers
                                     .Include(r => r.Driver)
                                     .Include(r => r.RideRequest)
                                     .FirstOrDefaultAsync(r => r.RideOfferId == rideId);
            if (ride == null)
            {
                return null;
            }
            return _mapper.Map<RideOfferDTO>(ride);
        }

        public async Task<IEnumerable<RideOfferDTO>> GetRidesOfferByDriverIdAsync(string driverId)
        {
            var rides = await _context.RideOffers
                                      .Where(r => r.DriverId == driverId)
                                      .Include(r => r.Driver)    
                                     .Include(r => r.RideRequest) 
                                      
                                      .ToListAsync();
            return _mapper.Map<IEnumerable<RideOfferDTO>>(rides);
        }
        public async Task<RideOfferUpdateDto> CreateRideOfferAsync(RideOfferUpdateDto rideOfferAddDto)
        {
            var rideOffer = _mapper.Map<RideOffer>(rideOfferAddDto);
            _context.RideOffers.Add(rideOffer);
            await _context.SaveChangesAsync();
            return _mapper.Map<RideOfferUpdateDto>(rideOfferAddDto);
        }
        public async Task<bool> UpdateRideofferAsync(string rideId, RideOfferUpdateDto rideOfferUpdateDto)
        {
            var ride = await _context.RideOffers.FindAsync(rideId);
            if (ride == null)
            {
                return false;
            }

            _mapper.Map(rideOfferUpdateDto, ride);
            _context.RideOffers.Update(ride);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteRideOfferAsync(string rideOfferId)
        {
            var ride = await _context.RideOffers.FindAsync(rideOfferId);
            if (ride == null)
            {
                return false;
            }

            _context.RideOffers.Remove(ride);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
