using Tomnaia.DTO;

namespace Tomnaia.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetReviewsAsync();
        Task<ReviewDto> GetReviewByIdAsync(string reviewId);
        Task<ReviewDto> CreateReviewAsync(ReviewDto reviewDto);
        Task<bool> UpdateReviewAsync(ReviewDto reviewDto);
        Task<bool> DeleteReviewAsync(string reviewId);
    }
}
