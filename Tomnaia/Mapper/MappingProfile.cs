using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Tomnaia.DTO;
using Tomnaia.Entities;
using Tomnaia.Services.Authentication;
using AutoMapper;
using System.Net.Mail;

namespace Tomnaia.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUser, User>()
                   .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => new MailAddress(src.Email).User));
            CreateMap<UserDto, User>().ReverseMap();

        }
            
    }
}
