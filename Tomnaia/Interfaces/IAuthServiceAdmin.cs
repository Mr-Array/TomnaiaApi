using Microsoft.AspNetCore.Identity;
using Tomnaia.Services.Authentication;

namespace Tomnaia.Interfaces
{
    public interface IAuthServiceAdmin
    {
        Task<IdentityResult> RegisterAsync(RegisterAdmin registerAdmin);
        Task<bool> ConfirmEmailAsync(string email, string token);
        Task<LoginResult> LoginAsync(LoginUser loginUser);
        Task<LogoutResult> LogoutAsync();
        Task<bool> ForgetPasswordAsync(string email);
    }
}
