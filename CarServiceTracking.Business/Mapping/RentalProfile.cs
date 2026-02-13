using AutoMapper;
using CarServiceTracking.Core.DTOs.RentalDTOs;
using CarServiceTracking.Core.Entities;

namespace CarServiceTracking.Business.Mapping
{
    public class RentalProfile : Profile
    {
        public RentalProfile()
        {
            CreateMap<RentalVehicle, RentalVehicleListDTO>();
            CreateMap<RentalVehicle, RentalVehicleDetailDTO>();
            CreateMap<RentalVehicleCreateDTO, RentalVehicle>();
            CreateMap<RentalVehicleUpdateDTO, RentalVehicle>();

            CreateMap<RentalAgreement, RentalAgreementListDTO>()
                .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.RentalDays, opt => opt.MapFrom(src => src.TotalDays));

            CreateMap<RentalAgreement, RentalAgreementDetailDTO>()
                .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.RentalDays, opt => opt.MapFrom(src => src.TotalDays));
            CreateMap<RentalAgreementCreateDTO, RentalAgreement>();
            CreateMap<RentalAgreementUpdateDTO, RentalAgreement>();
        }
    }
}
