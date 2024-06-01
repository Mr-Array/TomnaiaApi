using Tomnaia.DTO;

namespace Tomnaia.Interfaces
{
    public interface IUserAdminService
    {
        Task<AdminstratorDTO> GetCurrentUserAdminInfoAsync();
        Task<AdminstratorDTO> GetUserAdminByIdAsync(string id);
        Task<List<AdminstratorDTO>> GetUsersAdminByNameAsync(string name);
        Task<bool> UpdateUserAdminInfoAsync(AdminstratorDTO adminstratorDTO);
        Task<bool> DeleteAccountAdminAsync();

        Task<bool> DeleteUserAdminPictureAsync();
        Task<bool> UpdateUserAdminPictureAsync(IFormFile? file);

        Task<string> GetUserAdminPictureAsync();
      
    }
}
