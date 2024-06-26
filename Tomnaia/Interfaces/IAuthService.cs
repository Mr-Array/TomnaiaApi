﻿using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Tomnaia.Services.Authentication;

namespace Tomnaia.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterUserModel registerUser);
        Task<bool> ConfirmEmailAsync(string email, string token);
         Task<LoginResult> LoginAsync(LoginUser loginUser);
         Task<LogoutResult> LogoutAsync();
        Task<bool> ForgetPasswordAsync(string email);
      
    }
}
