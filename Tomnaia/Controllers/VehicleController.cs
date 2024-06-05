using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tomnaia.DTO;
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
            return vehicles  != null ? Ok(vehicles) : BadRequest("user not found.");
        }

        // GET: api/vehicles/{id}
        [Authorize]

        [HttpGet("GetVehicle{id}")]
        public async Task<ActionResult<VehicleDto>> GetVehicle(string id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
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
        public async Task<ActionResult<VehicleDto>> CreateVehicle(VehicleDto vehicleDto)
        {
            var vehicle = await _vehicleService.CreateVehicleAsync(vehicleDto);
            return CreatedAtAction(nameof(GetVehicle), new { id = vehicle.VehicleId }, vehicle);
        }

        // PUT: api/vehicles/{id}
        [Authorize]

        [HttpPut("UpdateVehicle{id}")]
        public async Task<IActionResult> UpdateVehicle(string id, VehicleDto vehicleDto)
        {
            if (id != vehicleDto.VehicleId)
            {
                return BadRequest();
            }

            var result = await _vehicleService.UpdateVehicleAsync(vehicleDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/vehicles/{id}
        [Authorize]

        [HttpDelete("DeleteVehicle{id}")]
        public async Task<IActionResult> DeleteVehicle(string id)
        {
            var result = await _vehicleService.DeleteVehicleAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}