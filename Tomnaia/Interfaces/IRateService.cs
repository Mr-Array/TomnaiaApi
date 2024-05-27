using Tomnaia.DTO;

namespace Tomnaia.Interfaces
{
    public interface IRateService
    {
        Task<bool> AddRateAsync(string userId, RateDto rateDto);
        Task<bool> DeleteRateAsync(string userId);

    }
}
