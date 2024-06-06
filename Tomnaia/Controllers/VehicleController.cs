using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tomnaia.DTO;
using Tomnaia.Entities;
using Tomnaia.Interfaces;

namespace Tomnaia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: api/vehicles
        [Authorize]

        [HttpGet("GetVehicles")]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> GetVehicles()
        {
            var vehicles = await _vehicleService.GetVehiclesAsync();
            return vehicles  != null ? Ok(vehicles) : BadRequest("Vehicle not found.");
        }

        // GET: api/vehicles/{id}
        [Authorize]

        [HttpGet("GetVehicle{id}")]
        public async Task<ActionResult<VehicleDto>> GetVehicle(string id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound("Vehicle not found.");
            }
            return Ok(vehicle);
        }

        // GET: api/vehicles/driver/{driverId}
        [Authorize]

        [HttpGet("driver/{driverId}")]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> GetVehiclesByDriver(string driverId)
        {
            var vehicles = await _vehicleService.GetVehiclesByDriverIdAsync(driverId);
            return vehicles != null ? Ok(vehicles) : BadRequest("user not found.");
        }

        // POST: api/vehicles
        [Authorize]

        [HttpPost("CreateVehicle")]
        public async Task<ActionResult<VehicleAddDto>> CreateVehicle(VehicleAddDto vehicleAddDto)
        {
            var vehicle = await _vehicleService.CreateVehicleAsync(vehicleAddDto);
            // return CreatedAtAction(nameof(GetVehicle), new {  }, vehicle);
            return Ok("Vehicle Add successfully.");
        }

        // PUT: api/vehicles/{id}
        [Authorize]

        [HttpPut("UpdateVehicle")]
        public async Task<IActionResult> UpdateVehicle(string vehicleId, VehicleUpdateDto vehicleUpdateDto)
        {
            if (vehicleUpdateDto == null)
            {
                return BadRequest("Vehicle data is null.");
            }

            var result = await _vehicleService.UpdateVehicleAsync(vehicleId, vehicleUpdateDto);
            if (!result)
            {
                return NotFound("Vehicle not found.");
            }

            return Ok("Vehicle updated successfully.");
        }

        // DELETE: api/vehicles/{id}
        [Authorize]

        [HttpDelete("DeleteVehicle{id}")]
        public async Task<IActionResult> DeleteVehicle(string id)
        {
            var result = await _vehicleService.DeleteVehicleAsync(id);
            if (!result)
            {
                return NotFound("Vehicle not found.");
            }

            return Ok("Vehicle deleted successfully.");
        }
    }
}