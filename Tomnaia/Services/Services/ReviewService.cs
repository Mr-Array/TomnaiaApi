using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tomnaia.Data;
using Tomnaia.DTO;
using Tomnaia.Entities;
using Tomnaia.Interfaces;

namespace Tomnaia.Services.Services
{
    public class ReviewService : IReviewService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ReviewService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsAsync()
        {
            var reviews = await _context.Reviews
                
              
                .Include(r => r.Rides)    // Include Vehicle navigation property
                                     .Include(r => r.Reviewer) // Include Passenger navigation property
                                      .Include(r => r.Reviewee) // Include Reviews navigation property
               
                                      .ToListAsync();
            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }
      
        public async Task<ReviewDto> GetReviewByIdAsync(string reviewId)
        {
            var review = await _context.Reviews.Include(r => r.Rides).FirstOrDefaultAsync(r => r.ReviewId == reviewId);
            if (review == null)
            {
                return null;
            }
            return _mapper.Map<ReviewDto>(review);
        }
       

        public async Task<ReviewAddDto> CreateReviewAsync(ReviewAddDto reviewAddDto)
        {
            var review = _mapper.Map<Review>(reviewAddDto);
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return _mapper.Map<ReviewAddDto>(review);
        }

        public async Task<bool> UpdateReviewAsync(string reviewId , ReviewUpdateDto reviewUpdateDto)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                return false;
            }

            _mapper.Map(reviewUpdateDto, review);
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteReviewAsync(string reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                return false;
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
