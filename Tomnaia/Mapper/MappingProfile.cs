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
            CreateMap<VehicleUpdateDto, Vehicle>().ReverseMap();
            CreateMap<VehicleAddDto, Vehicle>().ReverseMap();
            CreateMap<Vehicle, VehicleDto>();
            CreateMap<VehicleDto, Vehicle>();


            CreateMap<Ride, RideDto>();
            CreateMap<RideDto, Ride>();
            CreateMap<ReviewAddDto, Review>().ReverseMap();
            CreateMap<ReviewUpdateDto, Review>().ReverseMap();
            CreateMap<ReviewDto, Review>().ReverseMap();
            //CreateMap<AdminstratorDTO, User>().ReverseMap();

            CreateMap<UserResultDto, User>().ReverseMap();
            CreateMap<AdminstratorDTO, User>().ReverseMap();
            CreateMap<PassengerDto, User>().ReverseMap();
            CreateMap<DriverDto, User>().ReverseMap();
         
            CreateMap<RegisterUserModel, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => new MailAddress(src.Email).User));

            CreateMap<RegisterUserModel, Passenger>()
                .IncludeBase<RegisterUserModel, User>();

            CreateMap<RegisterUserModel, Driver>()
                .IncludeBase<RegisterUserModel, User>()
                .ForMember(dest => dest.expirDate, opt => opt.MapFrom(src => src.ExpirDate));

            CreateMap<RegisterUserModel, Adminstrator>()
                .IncludeBase<RegisterUserModel, User>();
            CreateMap<SendMessageDto, Message>()
               .ForMember(dest => dest.Id, opt => opt.Ignore()) 
               .ForMember(dest => dest.Timestamp, opt => opt.Ignore());

            CreateMap<Notification, NotificationResultDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Timestamp));
            CreateMap<RideDto, Ride>();


        }

    }
}

