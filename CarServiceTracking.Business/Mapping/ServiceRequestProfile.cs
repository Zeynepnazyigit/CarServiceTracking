using AutoMapper;
using CarServiceTracking.Core.DTOs.ServiceRequestDTOs;
using CarServiceTracking.Core.Entities;

namespace CarServiceTracking.Business.Mapping
{
    public class ServiceRequestProfile : Profile
    {
        public ServiceRequestProfile()
        {
            // CREATE
            CreateMap<ServiceRequestCreateDTO, ServiceRequest>();

            // LIST
            CreateMap<ServiceRequest, ServiceRequestListDTO>()
                .ForMember(dest => dest.CarName,
                    opt => opt.MapFrom(src =>
                        src.Car != null
                            ? src.Car.Brand + " " + src.Car.Model
                            : ""))
                .ForMember(dest => dest.ProblemDescription,
                    opt => opt.MapFrom(src => src.ProblemDescription))
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => (int)src.Status))
                .ForMember(dest => dest.PreferredDate,
                    opt => opt.MapFrom(src => src.PreferredDate));

            // DETAIL
            CreateMap<ServiceRequest, ServiceRequestDetailDTO>()
                .ForMember(dest => dest.CarName,
                    opt => opt.MapFrom(src =>
                        src.Car != null
                            ? src.Car.Brand + " " + src.Car.Model
                            : ""));
        }
    }
}
