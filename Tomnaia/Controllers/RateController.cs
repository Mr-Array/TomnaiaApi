﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tomnaia.DTO;
using Tomnaia.Interfaces;

namespace Tomnaia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        #region fields
        private readonly IRateService _rateService;
        #endregion

        #region ctor
        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }
        #endregion
        #region rate actions
        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddRateAsync(string userId, RateDto rateDto)
        {
            var result = await _rateService.AddRateAsync(userId, rateDto);
            return result ? Ok("rate has been added successfully") : BadRequest("faild to add rate");
        }

        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteRateAsync(string rateId)
        {
            var result = await _rateService.DeleteRateAsync(rateId);
            return result ? Ok("rate has been deleted successfully") : BadRequest("faild to delete rate");
        }
        #endregion
    }
}
