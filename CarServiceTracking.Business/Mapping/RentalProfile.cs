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

            CreateMap<RentalAgreement, RentalAgreementListDTO>();
            CreateMap<RentalAgreement, RentalAgreementDetailDTO>();
            CreateMap<RentalAgreementCreateDTO, RentalAgreement>();
            CreateMap<RentalAgreementUpdateDTO, RentalAgreement>();
        }
    }
}
