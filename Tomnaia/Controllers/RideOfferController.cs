using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tomnaia.DTO;
using Tomnaia.Entities;
using Tomnaia.Interfaces;
using Tomnaia.Services.Services;

namespace Tomnaia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideOfferController : ControllerBase
    {
        private readonly IRideOfferService _rideOfferService;

        public RideOfferController(IRideOfferService rideOfferService)
        {
            _rideOfferService = rideOfferService;
        }

        [Authorize]

        [HttpGet("GetRidesOffer")]
        public async Task<ActionResult<IEnumerable<RideOfferDTO>>> GetRidesOfferAsync()
        {
            var rides = await _rideOfferService.GetRidesOfferAsync();
            if (rides == null)
            {
                return NotFound("Ride Offer not found.");
            }
            return Ok(rides);
        }

        // GET: api/rides/{id}
        [Authorize]

        [HttpGet("GetRideOffer{id}")]
        public async Task<ActionResult<RideOfferDTO>> GetRideOfferByIdAsync(string id)
        {
            var ride = await _rideOfferService.GetRideOfferByIdAsync(id);
            if (ride == null)
            {
                return NotFound("Ride Offer not found.");
            }
            return Ok(ride);
        }


        [Authorize]

        [HttpGet("driver/{driverId}")]
        public async Task<ActionResult<IEnumerable<RideOfferDTO>>> GetRidesOfferByDriver(string driverId)
        {
            var rides = await _rideOfferService.GetRidesOfferByDriverIdAsync(driverId);
            if (rides == null)
            {
                return NotFound("Ride Offer Driver not found.");
            }
            return Ok(rides);
        }

        [Authorize]

        [HttpPost("CreateRideOffer")]
        public async Task<ActionResult<RideOfferUpdateDto>> CreateRideOffer(RideOfferUpdateDto rideOfferAddDto)
        {
            var ride = await _rideOfferService.CreateRideOfferAsync(rideOfferAddDto);
            return Ok("Ride Offer Add successfully.");
        }


        [Authorize]

        [HttpPut("UpdateRideOffer{id}")]
        public async Task<IActionResult> UpdateRideofferAsync(string id, RideOfferUpdateDto rideOfferUpdateDto)
        {
            if (rideOfferUpdateDto == null)
            {
                return BadRequest("Ride Offer data is null.");
            }

            var result = await _rideOfferService.UpdateRideofferAsync(id, rideOfferUpdateDto);
            if (!result)
            {
                return NotFound("Ride Offer not found.");
            }

            return Ok("Ride Offer updated successfully.");
        }



        [Authorize]

        [HttpDelete("DeleteRideOffer{id}")]
        public async Task<IActionResult> DeleteRideOffer(string id)
        {
            var result = await _rideOfferService.DeleteRideOfferAsync(id);
            if (!result)
            {
                return NotFound("Ride Offer not found.");
            }

            return Ok("Ride Offer deleted successfully.");
        }
    }
}
