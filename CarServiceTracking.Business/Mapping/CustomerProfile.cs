using AutoMapper;
using CarServiceTracking.Core.DTOs.CustomerDTOs;
using CarServiceTracking.Core.Entities;

namespace CarServiceTracking.Business.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            // =========================
            // LIST
            // =========================
            CreateMap<Customer, CustomerListDTO>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.CustomerTypeName,
                    opt => opt.MapFrom(src => src.CustomerType != null ? src.CustomerType.Name : ""))
                .ForMember(dest => dest.TotalVehicles, opt => opt.Ignore())
                .ForMember(dest => dest.TotalServices, opt => opt.Ignore());

            CreateMap<Customer, CustomerListItemDTO>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            // =========================
            // DETAIL
            // =========================
            CreateMap<Customer, CustomerDetailDTO>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.CustomerTypeName,
                    opt => opt.MapFrom(src => src.CustomerType != null ? src.CustomerType.Name : ""))
                .ForMember(dest => dest.TotalVehicles, opt => opt.Ignore())
                .ForMember(dest => dest.TotalServices, opt => opt.Ignore())
                .ForMember(dest => dest.CompletedServices, opt => opt.Ignore())
                .ForMember(dest => dest.PendingServices, opt => opt.Ignore());

            // =========================
            // CREATE (Admin tarafı)
            // =========================
            CreateMap<CustomerCreateDTO, Customer>();

            // =========================
            // SIGNUP (Auth tarafı - YENİ)
            // =========================
            CreateMap<CustomerSignupDTO, Customer>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true));

            // UpdateDTO -> Customer mapping YOK (manuel mapping kullanılıyor)
        }
    }
}
