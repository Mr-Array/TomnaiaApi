using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tomnaia.Consts;
using Tomnaia.Entities;
using Tomnaia.Services.Authentication;

namespace Tomnaia.Helpers
{
    internal class UserHelpers : IUserHelpers
    {
        #region fields
        private IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        #endregion

        #region ctor
        public UserHelpers(IConfiguration config, UserManager<User> userManager
            , IHttpContextAccessor contextAccessor
            , IWebHostEnvironment webHostEnvironment)
        {
            _config = config;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region methods
        public async Task<User> GetCurrentUserAsync()
        {
            var currentUser = _contextAccessor.HttpContext.User;
            return await _userManager.GetUserAsync(currentUser);
        }

        public async Task<LoginResult> GenerateJwtTokenAsync(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenExpiration = DateTime.Now.AddDays(1);
            var token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                claims: claims,
                expires: tokenExpiration,
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new LoginResult
            {
                Success = true,
                Token = tokenString,
                Expiration = token.ValidTo
            };
        }
        #endregion

        #region file handling
        

        public async Task<bool> DeleteFileAsync(string filePath, string folderName)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return true;
            }

            string rootPath = _webHostEnvironment.WebRootPath;
            var user = await GetCurrentUserAsync();
            string userName = user.UserName;

           
            string fullFilePath = Path.Combine(rootPath, filePath.TrimStart('/'));

            if (File.Exists(fullFilePath))
            {
                File.Delete(fullFilePath);
                return true;
            }
            else
            {
                throw new FileNotFoundException("File not found.", fullFilePath);
            }

        }

        public Task<string> AddFileAsync(IFormFile file, string folderName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
