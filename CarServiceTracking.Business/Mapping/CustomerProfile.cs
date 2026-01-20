using AutoMapper;
using CarServiceTracking.Core.DTOs.CustomerDTOs;
using CarServiceTracking.Core.Entities;

namespace CarServiceTracking.Business.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerListDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.CustomerTypeName, opt => opt.MapFrom(src => src.CustomerType != null ? src.CustomerType.Name : ""))
                .ForMember(dest => dest.TotalVehicles, opt => opt.Ignore())
                .ForMember(dest => dest.TotalServices, opt => opt.Ignore());

            CreateMap<Customer, CustomerListItemDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<Customer, CustomerDetailDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.CustomerTypeName, opt => opt.MapFrom(src => src.CustomerType != null ? src.CustomerType.Name : ""))
                .ForMember(dest => dest.TotalVehicles, opt => opt.Ignore())
                .ForMember(dest => dest.TotalServices, opt => opt.Ignore())
                .ForMember(dest => dest.CompletedServices, opt => opt.Ignore())
                .ForMember(dest => dest.PendingServices, opt => opt.Ignore());

            CreateMap<CustomerCreateDTO, Customer>();

            // UpdateDTO -> Customer mapping YOK (manuel mapping kullanılıyor)
        }
    }
}