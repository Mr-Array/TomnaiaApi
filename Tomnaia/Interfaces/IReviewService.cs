using Tomnaia.DTO;

namespace Tomnaia.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetReviewsAsync();
        Task<ReviewDto> GetReviewByIdAsync(string reviewId);
        Task<ReviewAddDto> CreateReviewAsync(ReviewAddDto reviewAddDto);
        Task<bool> UpdateReviewAsync(string reviewId ,ReviewUpdateDto reviewUpdateDto);
        Task<bool> DeleteReviewAsync(string reviewId);
    }
}
