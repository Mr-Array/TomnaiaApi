using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tomnaia.DTO;
using Tomnaia.Interfaces;

namespace Tomnaia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region fields
        private readonly IUserService _userService;
        #endregion

        #region ctor
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region user actions
        [Authorize]
        [HttpGet("get-Current-user")]
        public async Task<IActionResult> GetCurrentUserInfoAsync()
        {
            var result = await _userService.GetCurrentUserInfoAsync();
            return result != null ? Ok(result) : BadRequest(" user not found.");
        }

        [Authorize]
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetUserByIDAsync(string id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            return result != null ? Ok(result) : BadRequest("user not found.");
        }
        [Authorize]
        [HttpGet("get-by-name")]
        public async Task<IActionResult> GetUserNameAsync(string name)
        {
            var result = await _userService.GetUsersByNameAsync(name);
            return Ok(result);
        }
        [Authorize]
        [HttpPut("update-info")]
        public async Task<IActionResult> UpdateUserInfoAsync(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var success = await _userService.UpdateUserInfoAsync(userDto);
            return success ? Ok("user information updated successfully.") :
                BadRequest("Failed to update user information.");
        }

        [HttpDelete("delete-account")]
        public async Task<IActionResult> DeleteAccountAsync()
        {
            var success = await _userService.DeleteAccountAsync();
            return success ? Ok() : BadRequest("faild to delete user");
        }
        #endregion

        #region file handling
        [Authorize]
        [HttpGet("get-picture")]
        public async Task<IActionResult> GetUserPictureAsync()
        {
            var result = await _userService.GetUserPictureAsync();
            return Ok(result);
        }

        [Authorize]
        [HttpPut("Update-picture")]
        public async Task<IActionResult> UpdateUserPictureAsync(IFormFile file)
        {
            var result = await _userService.UpdateUserPictureAsync(file);
            return result ? Ok("picture has been added successfully.") : BadRequest("failed to add picture");
        }
        [Authorize]
        [HttpDelete("delete-picture")]
        public async Task<IActionResult> DeleteUserPictureAsync()
        {
            var result = await _userService.DeleteUserPictureAsync();
            return result ? Ok("picture has been deleted successfully.") : BadRequest("failed to delete picture");
        }
        #endregion

    }
}
