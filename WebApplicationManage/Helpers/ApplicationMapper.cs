using AutoMapper;
using WebApplicationManage.Data;
using WebApplicationManage.models.Producer;
using WebApplicationManage.models.User;

namespace WebApplicationManage.Helpers
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper()
        {
          CreateMap<ProducerDto, Producter>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
             .ForMember(dest => dest.Keyword, opt => opt.MapFrom(src => src.Keyword))
             .ForMember(dest => dest.Created , opt => opt.MapFrom(src => DateTime.Now)).ReverseMap();

            CreateMap<RegisterDto, User>()
               .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
            ).ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email)
            ).ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password))
                );

            CreateMap<LoginDto, User>()
                .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email)
            ).ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password))
                );

            CreateMap<User, UserDto>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email));
        }
    }
}
