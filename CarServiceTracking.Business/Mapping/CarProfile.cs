using AutoMapper;
using CarServiceTracking.Core.DTOs.CarDTOs;
using CarServiceTracking.Core.Entities;

namespace CarServiceTracking.Business.Mapping
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarCreateDTO, Car>();

            CreateMap<Car, CarListDTO>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src =>
                    src.Customer != null ? $"{src.Customer.FirstName} {src.Customer.LastName}" : ""))
                .ForMember(dest => dest.FuelTypeName, opt => opt.MapFrom(src =>
                    src.FuelTypeItem != null ? src.FuelTypeItem.Name : ""))
                .ForMember(dest => dest.TransmissionTypeName, opt => opt.MapFrom(src =>
                    src.TransmissionTypeItem != null ? src.TransmissionTypeItem.Name : ""))
                .ForMember(dest => dest.CarTypeName, opt => opt.MapFrom(src =>
                    src.CarTypeItem != null ? src.CarTypeItem.Name : ""));

            CreateMap<Car, CarListItemDTO>()
                .ForMember(dest => dest.BrandModel, opt => opt.MapFrom(src => $"{src.Brand} {src.Model}"));

            CreateMap<Car, CarDetailDTO>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src =>
                    src.Customer != null ? $"{src.Customer.FirstName} {src.Customer.LastName}" : ""))
                .ForMember(dest => dest.FuelTypeName, opt => opt.MapFrom(src =>
                    src.FuelTypeItem != null ? src.FuelTypeItem.Name : ""))
                .ForMember(dest => dest.TransmissionTypeName, opt => opt.MapFrom(src =>
                    src.TransmissionTypeItem != null ? src.TransmissionTypeItem.Name : ""))
                .ForMember(dest => dest.CarTypeName, opt => opt.MapFrom(src =>
                    src.CarTypeItem != null ? src.CarTypeItem.Name : ""));

            // UpdateDTO -> Car mapping YOK (manuel mapping var)
        }
    }
}
