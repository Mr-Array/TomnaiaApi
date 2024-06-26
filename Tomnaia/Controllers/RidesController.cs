﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tomnaia.DTO;
using Tomnaia.Entities;
using Tomnaia.Interfaces;
using Tomnaia.Mapper;
using Tomnaia.Services.Services;

namespace Tomnaia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RidesController : ControllerBase
    {
        private readonly IRideService _rideService;

        public RidesController(IRideService rideService)
        {
            _rideService = rideService;
        }

        // GET: api/rides
        [Authorize]

        [HttpGet("GetRides")]
        public async Task<ActionResult<IEnumerable<RideDto>>> GetRides()
        {
            var rides = await _rideService.GetRidesAsync();
            if (rides == null)
            {
                return NotFound("Ride not found.");
            }
            return Ok(rides);
        }

        // GET: api/rides/{id}
        [Authorize]

        [HttpGet("GetRide{id}")]
        public async Task<ActionResult<RideDto>> GetRide(string id)
        {
            var ride = await _rideService.GetRideByIdAsync(id);
            if (ride == null)
            {
                return NotFound("Ride not found.");
            }
            return Ok(ride);
        }

        // GET: api/rides/driver/{driverId}
        [Authorize]

        [HttpGet("driver/{driverId}")]
        public async Task<ActionResult<IEnumerable<RideDto>>> GetRidesByPassenger(string driverId)
        {
            var rides = await _rideService.GetRidesByDriverIdAsync(driverId);
            if (rides == null)
            {
                return NotFound("Ride Passenger not found.");
            }
            return Ok(rides);
        }

        // POST: api/rides
        [Authorize]

        [HttpPost("CreateRide")]
        public async Task<ActionResult<RideDto>> CreateRide(RideAddDto rideAddDto)
        {
            var ride = await _rideService.CreateRideAsync(rideAddDto);
              return Ok("Ride Add successfully.");
        }

        // PUT: api/rides/{id}
        [Authorize]

        [HttpPut("UpdateRide{id}")]
        public async Task<IActionResult> UpdateRide(string id, RideUpdateDto rideUpdateDto)
        {
            if (rideUpdateDto == null)
            {
                return BadRequest("Ride data is null.");
            }

            var result = await _rideService.UpdateRideAsync(id , rideUpdateDto);
            if (!result)
            {
                return NotFound("Ride not found.");
            }

            return Ok("Ride updated successfully.");
        }

        // DELETE: api/rides/{id}
        [Authorize]

        [HttpDelete("DeleteRide{id}")]
        public async Task<IActionResult> DeleteRide(string id)
        {
            var result = await _rideService.DeleteRideAsync(id);
            if (!result)
            {
                return NotFound("Ride not found.");
            }

            return Ok("Ride deleted successfully.");
        }
    }
}
