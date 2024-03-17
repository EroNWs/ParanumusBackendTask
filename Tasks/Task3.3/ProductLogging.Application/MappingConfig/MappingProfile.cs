using AutoMapper;
using ProductLogging.Dtos;
using ProductLogging.Models;

namespace ProductLogging.Application.MappingConfig;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
       CreateMap<RegisterUserDtos, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => src.EmailConfirmed))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.MapFrom(src => src.PhoneNumberConfirmed))
            .ForMember(dest => dest.TwoFactorEnabled, opt => opt.MapFrom(src => src.TwoFactorEnabled))
            .ForMember(dest => dest.LockoutEnabled, opt => opt.MapFrom(src => src.LockoutEnabled))
            .ForMember(dest => dest.AccessFailedCount, opt => opt.MapFrom(src => src.AccessFailedCount))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src=>src.FirstName)) 
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src=>src.LastName));

        CreateMap<UserAuthenticationDto, UserLogin>().ReverseMap();

        CreateMap<ProductCreateDto, Product>().ReverseMap();
        CreateMap<ProductDto, Product>().ReverseMap();  
    }
}
