﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tomnaia.Interfaces;
using Tomnaia.Services.Authentication;

namespace Tomnaia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        #region fields
        private readonly IAuthService _authService;
        #endregion

        #region ctor
        public AuthorizationController(IAuthService authService)
        {
            _authService = authService;
        }
        #endregion

        #region registration
        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterUserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.RegisterAsync(user);
            if (result.Succeeded)
            {
                return Ok("Registration succeeded.");
            }
            return BadRequest(result.Errors);
        }


        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string email, [FromQuery] string token)
        {
            var success = await _authService.ConfirmEmailAsync(email, token);
            if (success)
                return Ok("Email confirmed successfully.");

            return BadRequest("Failed to confirm email.");
        }
        #endregion

        #region login & logout
        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginUser loginUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.LoginAsync(loginUser);
            if (result.Success)
                return Ok(result);

            string errorMessage;
            if (result.ErrorType == LoginErrorType.UserNotFound)
            {
                errorMessage = "User not found.";
            }
            else if (result.ErrorType == LoginErrorType.InvalidPassword)
            {
                errorMessage = "Incorrect password.";
            }
            else if (result.ErrorType == LoginErrorType.EmailNotComfirmed)
            {
                errorMessage = "Email Not Comfirmed.";
            }
            else
            {
                errorMessage = "Invalid login attempt.";
            }

            ModelState.AddModelError(string.Empty, errorMessage);
            return Unauthorized(ModelState);
        }
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            var result = await _authService.LogoutAsync();

            if (result.Success)
            {
                return Ok(new { message = result.Message });
            }
            else
            {
                return BadRequest(new { error = result.Message });
            }
        }
        #endregion

        #region forget & reset & change password
        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPasswordAsync(string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isSent = await _authService.ForgetPasswordAsync(email);
            if (isSent)
            {
                return Ok("Reset password email sent successfully.");
            }
            else
            {
                return NotFound("User with provided email not found.");
            }
        }

        [HttpGet("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(string token, string email)
        {
            var model = new ResetPassword { Token = token, Email = email };

            return Ok(new { model });
        }
        #endregion
        
    }
}
