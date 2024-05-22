

using Tomnaia.Helpers;
using Tomnaia.Interfaces;
using Tomnaia.Mapper;
using Tomnaia.Services.Mail;
using Tomnaia.Services.Services;

namespace Tomnaia
{
    public static class ModuleServicesDependences
    {
        public static IServiceCollection AddReposetoriesServices(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(MappingProfile));
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IAuthService, AuthService>();
            service.AddTransient<IUserHelpers, UserHelpers>();
            service.AddScoped<IMailingService, MailingService>();
            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return service;
        }
    }
}
