using AutoMapper;
using WebApplicationManage.Data;
using WebApplicationManage.models.Category;
using WebApplicationManage.models.Customer;
using WebApplicationManage.models.Order;
using WebApplicationManage.models.Producer;
using WebApplicationManage.models.Product;
using WebApplicationManage.models.User;

namespace WebApplicationManage.Helpers
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper()
        {
            //producer
          CreateMap<ProducerDto, Producer>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.Keyword, opt => opt.MapFrom(src => src.Keyword))
            .ForMember(dest => dest.Created , opt => opt.MapFrom(src => DateTime.Now)).ReverseMap();
            //category
            CreateMap<CategoryDto, Category>().ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.Now)).ReverseMap();

            //product
            CreateMap<ProductDto, Product>()
            .ForMember(dest => dest.producer, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.OrderDetails, opt => opt.Ignore());

            //orderDto 
               CreateMap<Order, OrderDto>().ForMember(dest => dest.Email, opt => opt.Ignore()).ReverseMap();

            //user
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

            //Customer
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.Now)).ReverseMap();

            CreateMap<RegisterCustomerDto, Customer>()
               .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName)
            ).ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email)
            ).ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password))
                ).ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.Now)).ReverseMap();

                CreateMap<OrderDto, Customer>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.Now)).ReverseMap();

            CreateMap<LoginCustomerDto, Customer>()
                .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email)
            ).ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password))
                );
        }
    }
}
