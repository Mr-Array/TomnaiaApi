using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tomnaia.DTO;
using Tomnaia.Interfaces;

namespace Tomnaia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: api/reviews
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviews()
        {
            var reviews = await _reviewService.GetReviewsAsync();
            return Ok(reviews);
        }

        // GET: api/reviews/5
        [Authorize]
        [HttpGet("GetReview{id}")]
        public async Task<ActionResult<ReviewDto>> GetReview(string id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound("Review not found.");
            }
            return Ok(review);
        }

        // POST: api/reviews
        [Authorize]
        [HttpPost("CreateReview")]
        public async Task<ActionResult<ReviewDto>> CreateReview(ReviewAddDto reviewAddDto)
        {
            var review = await _reviewService.CreateReviewAsync(reviewAddDto);
            // return CreatedAtAction(nameof(GetReview), new { }, review);
            return Ok("Review Add successfully.");
        }

        // PUT: api/reviews/5
        [Authorize]
        [HttpPut("UpdateReview{id}")]
        public async Task<IActionResult> UpdateReview(string id, ReviewUpdateDto reviewUpdateDto)
        {
            if (reviewUpdateDto == null)
            {
                return BadRequest("Review data is null.");
            }

            var result = await _reviewService.UpdateReviewAsync(id , reviewUpdateDto);
            if (!result)
            {
                return NotFound("Review not found.");
            }

            return Ok("Review updated successfully.");
        }

        // DELETE: api/reviews/5
        [Authorize]
        [HttpDelete("DeleteReview{id}")]
        public async Task<IActionResult> DeleteReview(string id)
        {
            var result = await _reviewService.DeleteReviewAsync(id);
            if (!result)
            {
                return NotFound("Review not found.");
            }

            return Ok("Review deleted successfully.");
        }
    }
}