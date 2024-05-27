using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Tomnaia.DTO;
using Tomnaia.Entities;
using Tomnaia.Services.Authentication;
using AutoMapper;
using System.Net.Mail;
using Abp.Application.Services.Dto;

namespace Tomnaia.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUser, User>()
                   .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => new MailAddress(src.Email).User));
            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<MessageResultDto, Message>().ReverseMap();
            
            CreateMap<Comment, CommentDto>();
            CreateMap<Notification, NotificationResultDto>();

            CreateMap<User, UserResultDto>()
                .ForMember(dest => dest.RateCount, opt => opt.MapFrom(src => src.ReceivedRates.Count()))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => CalculateAverageRate(src)));
               

            CreateMap<Rate, RateDto>();
           
            CreateMap<SendMessageDto, Message>()
               .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => DateTime.Now.ToLocalTime()));

            CreateMap<AddCommentDto, Comment>()
               .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => DateTime.Now.ToLocalTime()));
            
        }
        private double CalculateAverageRate(User user)
        {
            if (user.ReceivedRates == null || user.ReceivedRates.Count == 0)
            {
                return 0;
            }

            double totalRate = 0;
            foreach (var rate in user.ReceivedRates)
            {
                totalRate += rate.RateValue;
            }

            return totalRate / user.ReceivedRates.Count;
        }
    }
}

