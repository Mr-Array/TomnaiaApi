using Tomnaia.DTO;

namespace Tomnaia.Interfaces
{
    public interface IUserService
    {
        Task<UserResultDto> GetCurrentUserInfoAsync();
        Task<UserResultDto> GetUserByIdAsync(string id);
        Task<List<UserResultDto>> GetUsersByNameAsync(string name);
        Task<bool> UpdateUserInfoAsync(UserDto userDto);
        Task<bool> DeleteAccountAsync();
      
        Task<bool> DeleteUserPictureAsync();
        Task<bool> UpdateUserPictureAsync(IFormFile? file);
       
        Task<string> GetUserPictureAsync();
        Task<bool> DeleteUserCVAsync();
        

    }
}
