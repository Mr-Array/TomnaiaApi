using System.Security.Claims;
using Tomnaia.Entities;
using Tomnaia.Services.Authentication;

namespace Tomnaia.Helpers
{
    public interface IUserHelpers
    {
        Task<LoginResult> GenerateJwtTokenAsync(IEnumerable<Claim> claims);
        Task<User> GetCurrentUserAsync();
        Task<string> AddFileAsync(IFormFile file, string folderName);
        Task<bool> DeleteFileAsync(string imagePath, string folderName);
    }
}
